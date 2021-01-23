    static void Main(string[] args)
                {
                    try
                    {
        
                        OleDbConnection oledbConn;
        
                        string path = System.IO.Path.GetFullPath(@"D:\FileName.XLS");
        
                        oledbConn = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" +
                                path + "';Extended Properties=Excel 8.0;");
        
                        oledbConn.Open();
                        OleDbCommand cmd = new OleDbCommand(); ;
                        OleDbDataAdapter oleda = new OleDbDataAdapter();
                        DataSet ds = new DataSet();
        
        
                        cmd.Connection = oledbConn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM [sheet]";
                        oleda = new OleDbDataAdapter(cmd);
                        oleda.Fill(ds, "dsSlno");
                        oledbConn.Close();
        
                    }
                    catch (Exception)
                    {
        
                        throw;
                    }
        
                }
