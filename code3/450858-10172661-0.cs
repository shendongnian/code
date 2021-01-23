    void backgroundWoker_DoWork(....)
    {
          for (int i = 0; i < 10000; i++)
          {
              backgroundWoker.ReportProgress(0,i.ToString());
              Thread.Sleep(1000);
          }
    
    }
    void backgroundWoker_ProgressChanged(....)
    {
         label1.Text = e.UserState.ToString();
    }
