    private void showrep(string repName)
            {
                rd = new ReportDocument();
                rd.Load(pth+"\\"+repName);
                LogInInfo();
    
                crv.ReportSource = rd;  // crv is the reportviewer
                crv.Show();
            }
    
            private void LogInInfo()
            {
                MyApp.Properties.Settings s = new MyApp.Properties.Settings();
                TableLogOnInfo linfo = new TableLogOnInfo();
                linfo.ConnectionInfo.DatabaseName = s.dbname;
                linfo.ConnectionInfo.UserID = s.usr;
                linfo.ConnectionInfo.Password = s.pw;
                linfo.ConnectionInfo.ServerName = s.svr;
    
                foreach (Table t in rd.Database.Tables)
                {
                    t.ApplyLogOnInfo(linfo);
                }
                foreach (ReportDocument sr in rd.Subreports)
                {
                    foreach (Table t in sr.Database.Tables )
                    {
                        t.ApplyLogOnInfo(linfo);
                    }
                }
            }
