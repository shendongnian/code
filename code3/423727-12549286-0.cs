    internal class SQLiteBulkInsert
    {
    #region Class Declarations
    private SQLiteCommand m_cmd;
    private SQLiteTransaction m_trans;
    private readonly SQLiteConnection m_dbCon;
    private readonly Dictionary<string, SQLiteParameter> m_parameters = new Dictionary<string, SQLiteParameter>();
    private uint m_counter;
    private readonly string m_beginInsertText;
    #endregion
    #region Constructor
    public SQLiteBulkInsert(SQLiteConnection dbConnection, string tableName)
    {
        m_dbCon = dbConnection;
        m_tableName = tableName;
        var query = new StringBuilder(255);
        query.Append("INSERT INTO ["); query.Append(tableName); query.Append("] (");
        m_beginInsertText = query.ToString();
    }
    #endregion
    #region Allow Bulk Insert
    private bool m_allowBulkInsert = true;
    public bool AllowBulkInsert { get { return m_allowBulkInsert; } set { m_allowBulkInsert = value; } }
    #endregion
    #region CommandText
    public string CommandText
    {
        get
        {
            if(m_parameters.Count < 1) throw new SQLiteException("You must add at least one parameter.");
            var sb = new StringBuilder(255);
            sb.Append(m_beginInsertText);
            foreach(var param in m_parameters.Keys)
            {
                sb.Append('[');
                sb.Append(param);
                sb.Append(']');
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(") VALUES (");
            foreach(var param in m_parameters.Keys)
            {
                sb.Append(m_paramDelim);
                sb.Append(param);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(")");
            return sb.ToString();
        }
    }
    #endregion
    #region Commit Max
    private uint m_commitMax = 25000;
    public uint CommitMax { get { return m_commitMax; } set { m_commitMax = value; } }
    #endregion
    #region Table Name
    private readonly string m_tableName;
    public string TableName { get { return m_tableName; } }
    #endregion
    #region Parameter Delimiter
    private const string m_paramDelim = ":";
    public string ParamDelimiter { get { return m_paramDelim; } }
    #endregion
    #region AddParameter
    public void AddParameter(string name, DbType dbType)
    {
        var param = new SQLiteParameter(m_paramDelim + name, dbType);
        m_parameters.Add(name, param);
    }
    #endregion
    #region Flush
    public void Flush()
    {
        try
        {
            if (m_trans != null) m_trans.Commit();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not commit transaction. See InnerException for more details", ex);
        }
        finally
        {
            if (m_trans != null) m_trans.Dispose();
            m_trans = null;
            m_counter = 0;
        }
    }
    #endregion
    #region Insert
    public void Insert(object[] paramValues)
    {
        if (paramValues.Length != m_parameters.Count) 
            throw new Exception("The values array count must be equal to the count of the number of parameters.");
        m_counter++;
        if (m_counter == 1)
        {
            if (m_allowBulkInsert) m_trans = m_dbCon.BeginTransaction();
            m_cmd = m_dbCon.CreateCommand();
            foreach (var par in m_parameters.Values)
                m_cmd.Parameters.Add(par);
            m_cmd.CommandText = CommandText;
        }
        var i = 0;
        foreach (var par in m_parameters.Values)
        {
            par.Value = paramValues[i];
            i++;
        }
        m_cmd.ExecuteNonQuery();
        if(m_counter != m_commitMax)
        {
            // Do nothing
        }
        else
        {
            try
            {
                if(m_trans != null) m_trans.Commit();
            }
            catch(Exception)
            { }
            finally
            {
                if(m_trans != null)
                {
                    m_trans.Dispose();
                    m_trans = null;
                }
                m_counter = 0;
            }
        }
    }
    #endregion
}
