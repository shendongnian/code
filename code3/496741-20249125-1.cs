    public bool updateCMStable(int id, string columnName, string columnText)
                {
                     try
                    {
    string sql = "UPDATE  CMStable SET '"+columnName+"' = '"+columnText+"' where cmdID='"+id+"'";
                             int i = SqlHelper.ExecuteNonQuery(Connection.ConnectionString,CommandType.Text,sql);
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
