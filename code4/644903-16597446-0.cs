    string connString = @"Provider=vfpoledb;Data Source=C:\Directory;Collating Sequence=machine;";
            using (OleDbConnection con = new OleDbConnection(connString))
            {
                con.Open();
                    OleDbCommand command = new OleDbCommand("Select * from Table.DBF", con);
                    OleDbDataReader reader = command.ExecuteReader();
                    ...
            }
