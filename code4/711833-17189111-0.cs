    public bool InsertRecord(string strTableName, string strColumn_Name, string strValues)
            {
     SqlConnection OBJCONNECTION;
                StringBuilder strbQuery;
                SqlCommand cmd;
                try
                {
    OBJCONNECTION= new SqlConnection();
    OBJCONNECTION.ConnectionString = ConfigurationManager.ConnectionStrings["Basic_ADO"].ConnectionString;//get connection string from web.config file
                   OBJCONNECTION=
                    strbQuery = new StringBuilder();
                    strbQuery.Append("INSERT INTO ");
                    strbQuery.Append(strTableName);
                    strbQuery.Append("(" + strColumn_Name + ")");
                    //strbQuery.Append(" VALUES");
                    strbQuery.Append("(" + strValues + ")");
                    cmd = new SqlCommand(strbQuery.ToString(), OBJCONNECTION);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { throw ex; }
                finally { strbQuery = null; cmd = null;OBJCONNECTION.close();}
    
            }
