    private void button1_Click(object sender, System.EventArgs e)
    {
       try
       {
          ReportDocument report = new ReportDocument();
          report.Load ("c:\\sample.rpt");
          report.PrintToPrinter (1,true,1,2);
       }
       catch (LogOnException engEx)
       {
          MessageBox.Show _
    ("Incorrect Logon Parameters. Check your user name and password.");
       }
       catch (DataSourceException engEx)
       {
       MessageBox.Show _
    ("An error has occurred while connecting to the database.");
       }
       catch (EngineException engEx)
       {
          MessageBox.Show (engEx.Message);
       }
    }
