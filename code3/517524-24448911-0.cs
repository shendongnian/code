            //declare variables - edit these based on your particular situation
            string ssqltable = "test_data";//sql table name
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if havedifferent
            string myexceldataquery = "select * from [Sheet1$]";
            try
            {
                //create our connection strings
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelfilepath + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                string ssqlconnectionstring = "server=ServerName;user id=sa;password=sa;database=Databasename;connection reset=false";
                //execute a query to erase any previous data from our destination table
                string sclearsql = "Delete from " + ssqltable;
                SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
                SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
                DataTable dt = new DataTable();
               
                bulkcopy.DestinationTableName = ssqltable;
                bulkcopy.WriteToServer(dr);
                oledbconn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
