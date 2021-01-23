        using(DbConnection myConn = dbFactory.CreateConnection())
        {
            myConn.ConnectionString = myConnectionStringSetting.ConnectionString;   
            DataTable myDataTable = new DataTable();   
            string[] varNamesArray = m_variableNames.Split(',');   
            foreach (string varName in varNamesArray)   
            {   
                ... 
                // the rest of your code
                ...
                // Then do not add the using statement here 
                myConn.Open(); 
                myCommand.ExecuteNonQuery(); 
                myConn.Close(); 
                ....
            }
        } 
