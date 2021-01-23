        public static List<Dictionary<string, object>> loadData(string sql)
        {
        itson = (sql.StartsWith("GetTimesWith"));
        DBManager dbManager = new DBManager(DataProvider.SqlServer, "Data Source=(local);Initial Catalog=hental;Integrated Security=True");
        //ArrayList data = new ArrayList();
        List<Dictionary<string, object>> data = new List<Dictionary<string,object>>();
        try
        {
            dbManager.Open();
            dbManager.ExecuteReader(System.Data.CommandType.Text, sql);
            while (dbManager.DataReader.Read())
            {
               //Hashtable x = new Hashtable();
               Dictionary<string, object> x = new Dictionary<string, object>();
                for (int i = 0; i < dbManager.DataReader.FieldCount; i++)
                {
                    x.Add(dbManager.DataReader.GetName(i), dbManager.DataReader.GetValue(i));
                }
                x.Add("COUNTER", data.Count+1);
                data.Add(x);
                ncx = data.Count;
            }
        }
        catch { data = null; }
        finally
        {
            dbManager.Dispose();
        }
        
        return data;
    }
