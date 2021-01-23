    public void FindOnPage()
        {
            var resource = Application.GetResourceStream(new Uri("Resources/FindOnPage/FindOnPage.txt", UriKind.Relative));
            string text;
            StreamReader sr = new StreamReader(resource.Stream);
    
            //while((text = sr.ReadToEnd()) != null) 
            if ((text = sr.ReadToEnd()) != null)
            {
            text = text.Replace("#search#",SearchBar.Text); //Replace SearchBar.Text with the string you want to search    
            TheWebBrowser.InvokeScript("eval", text);
            } 
        }
