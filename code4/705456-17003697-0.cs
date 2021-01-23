    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
         try
         {
             WebView1.InvokeScript("eval", "history.go(-1)");
         }
         catch {}
     }
