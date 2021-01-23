     protected override void OnFormClosing(FormClosingEventArgs e)
     {
        if (saved == true)
        {
           Environment.Exit(0);
        }
        else /* consider checking CloseReason: if (e.CloseReason != CloseReason.ApplicationExitCall) */
        {
           //You forgot to save
           e.Cancel = true;
        }
        base.OnFormClosing(e);
     }
