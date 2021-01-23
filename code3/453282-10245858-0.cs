      private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
         if (e.KeyData == Keys.Tab)
         {
            webBrowser.Document.ExecCommand("Indent", false, null);
            e.IsInputKey = true;    //prevents going to next control
         }
         else if (e.KeyData == (Keys.Shift | Keys.Tab))
         {
            webBrowser.Document.ExecCommand("Outdent", false, null);
            e.IsInputKey = true;
         }
      }
