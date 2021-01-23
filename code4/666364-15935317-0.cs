    protected void timer1Elapsed(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                if (mainProg == null)
                {
                    mainProg = new ProcessFilesFromSource(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                }
                mainProg.ScanArchiverMain();          
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ScanArchiver Error", ex.ToString());
                EventLog.WriteEntry("ScanArchiver Online");
            }            
            timer1.Start();
          }
