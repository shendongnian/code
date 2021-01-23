    using (var browser = new System.Windows.Forms.WebBrowser())
    {
         browser.DocumentCompleted += delegate
         {
             using (var pic = new Bitmap(browser.Width, browser.Height))
             {
                 browser.DrawToBitmap(pic, new Rectangle(0, 0, pic.Width, pic.Height));
                 pic.Save(imagePath);
             }
         };
         browser.Navigate(Server.MapPath("~") + htmlPath); //a file or a url
         browser.ScrollBarsEnabled = false;
           
         while (browser.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
         {
             System.Windows.Forms.Application.DoEvents();
         }
    }
            
