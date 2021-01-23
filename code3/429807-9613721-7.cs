    private void PingUpdate (object sender, ProgressUpdated e)
    {
         if (InvokeRequired)
         {
            Invoke(new Action<object, ProgressUpdated>(PingUpdate), sender, e);
            return;
         }
         
         toolStripStatusLabel1.Text = e.GeneralStatus;
         toolStripProgressBar2.Value = e.ProgressStatus;
         toolStripStatusLable3.Text = e.SepcificStatus;
    }
