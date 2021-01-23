    // From Type to DBType
    protected virtual System.Data.DbType GetDbType(Type type)
    {
        // http://social.msdn.microsoft.com/Forums/en/winforms/thread/c6f3ab91-2198-402a-9a18-66ce442333a6
        string strTypeName = type.Name;
        System.Data.DbType DBtype = System.Data.DbType.String; // default value
        try
        {
            if (object.ReferenceEquals(type, typeof(System.DBNull)))
            {
                return DBtype;
            }
            if (object.ReferenceEquals(type, typeof(System.Byte[])))
            {
                return System.Data.DbType.Binary;
            }
            DBtype = (System.Data.DbType)Enum.Parse(typeof(System.Data.DbType), strTypeName, true);
            // Es ist keine Zuordnung von DbType UInt64 zu einem bekannten SqlDbType vorhanden.
            // http://msdn.microsoft.com/en-us/library/bbw6zyha(v=vs.71).aspx
            if (DBtype == System.Data.DbType.UInt64)
                DBtype = System.Data.DbType.Int64;
        }
        catch (Exception)
        {
            // add error handling to suit your taste
        }
        return DBtype;
    } // End Function GetDbType
    public virtual System.Data.IDbDataParameter AddParameter(System.Data.IDbCommand command, string strParameterName, object objValue)
    {
        return AddParameter(command, strParameterName, objValue, System.Data.ParameterDirection.Input);
    } // End Function AddParameter
    public virtual System.Data.IDbDataParameter AddParameter(System.Data.IDbCommand command, string strParameterName, object objValue, System.Data.ParameterDirection pad)
    {
        if (objValue == null)
        {
            //throw new ArgumentNullException("objValue");
            objValue = System.DBNull.Value;
        } // End if (objValue == null)
        System.Type tDataType = objValue.GetType();
        System.Data.DbType dbType = GetDbType(tDataType);
        return AddParameter(command, strParameterName, objValue, pad, dbType);
    } // End Function AddParameter
    public virtual System.Data.IDbDataParameter AddParameter(System.Data.IDbCommand command, string strParameterName, object objValue, System.Data.ParameterDirection pad, System.Data.DbType dbType)
    {
        System.Data.IDbDataParameter parameter = command.CreateParameter();
        if (!strParameterName.StartsWith("@"))
        {
            strParameterName = "@" + strParameterName;
        } // End if (!strParameterName.StartsWith("@"))
        parameter.ParameterName = strParameterName;
        parameter.DbType = dbType;
        parameter.Direction = pad;
        // Es ist keine Zuordnung von DbType UInt64 zu einem bekannten SqlDbType vorhanden.
        // No association  DbType UInt64 to a known SqlDbType
        if (objValue == null)
            parameter.Value = System.DBNull.Value;
        else
            parameter.Value = objValue;
        command.Parameters.Add(parameter);
        return parameter;
    } // End Function AddParameter
    public virtual T GetParameterValue<T>(System.Data.IDbCommand idbc, string strParameterName)
    {
        if (!strParameterName.StartsWith("@"))
        {
            strParameterName = "@" + strParameterName;
        }
        return InlineTypeAssignHelper<T>(((System.Data.IDbDataParameter)idbc.Parameters[strParameterName]).Value);
    } // End Function GetParameterValue<T>
