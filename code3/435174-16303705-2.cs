      using Awesomium.Core;
      ...
      private void Button1_Click(object sender, RoutedEventArgs e)
      {
         JSObject window = webView.ExecuteJavascriptWithResult("window");
         if (window == null)
            return;
         using (window)
         {
            window.InvokeAsync("setDivText", "You pressed button 1.");            
         }
      }
