    public void FindOnPage()
        {
            var resource = Application.GetResourceStream(new Uri("Resources/FindOnPage.txt", UriKind.Relative));
            string text;
            StreamReader sr = new StreamReader(resource.Stream);
            
            //while((text = sr.ReadToEnd()) != null)
            if ((text = sr.ReadToEnd()) != null)
            {
                TheWebBrowser.InvokeScript("eval", text);
            }
        }
