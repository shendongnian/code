     private void MakeDSN()
            {
                try
                {
                    if (!System.IO.Directory.Exists(@"C:\OTPub"))
                    {
                        System.IO.Directory.CreateDirectory(@"C:\OTPub");
                    }
    
                    if (File.Exists(@"C:\OTPub\Ot.dsn"))    //delete ErrorLogFile
                    {
                        File.SetAttributes(@"C:\OTPub\Ot.dsn", FileAttributes.Temporary);
                        File.Delete(@"C:\OTPub\Ot.dsn");
                    }
                    string con = "[ODBC]";
                    string driver = "DRIVER=SQL Server";
                    string uid = "UID=sa";
                    string DB = "DATABASE=OTData";
                    string server = "SERVER=10.63.210.111";
    
                    var tw = new StreamWriter(@"C:\OTPub\Ot.dsn", true); // make file in location
                    using (tw)
                    {
                        tw.WriteLine(con);   //write  dataline
                        tw.WriteLine(driver);
                        tw.WriteLine(uid);
                        tw.WriteLine(DB);
                        tw.WriteLine(server);
                    }
    
                    lbserver.Text="LOGIN "+server;
                }
                catch (Exception)
                {
                    MessageBox.Show("File DSN Error!");
                }
            }
