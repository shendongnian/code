    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      foreach(WebControl awWebControl in WebCore.Views)
      {
         //Dispose all active views in WebCore
         awWebControl.Dispose();
      }
      //then you can Shutdown the WebCore
      WebCore.Shutdown();
    }
