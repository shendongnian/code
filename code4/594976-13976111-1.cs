    System.Windows.Forms.Timer yesTimer;
    yesTimer.Interval = 2000;
    public Main()
    {
      webBrowser1.Navigate("http://www.mysite.com");
      yesTimer.Start();
    }
      private void yesTimer_Tick(object sender, EventArgs e)
      {
         if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
         {
            return;
         }
         yesTimer.Stop();
         //do here whatever you want then webBrowser1 is completed
      }
