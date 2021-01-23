    string connstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\College\Year 2\Structured Programming\Go Greece Ver.1\Database\GoGreece.accdb;Persist Security Info=False;";
    
            
    
    using (OleDbConnection con = new OleDbConnection(connstr))
            {
                string SQlstring = string.Format("INSERT INTO [Hotels] (Name) VALUES ('{0}')", nametext);
                OleDbCommand cmd = new OleDbCommand(SQlstring, con);
    
                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                }
                catch(OleDbException Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
