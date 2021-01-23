    public bool updateCMStable(int id, string columnName, string columnText)
    {
        try
        {
            columnText=columnText.Replace("'","''")
            string sql = "UPDATE  CMStable SET " + columnName + 
                          "='" + columnText + "' WHERE cmsID=" + id;
            int i = SqlHelper.ExecuteNonQuery(Connection.ConnectionString,
                                              CommandType.Text,
                                              sql);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    } 
