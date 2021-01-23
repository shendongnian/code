      private void yesTimer_Tick(object sender, EventArgs e)
      {
         if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
         {
            return;
         }
         yesTimer.Stop();
      }
