    private void DisplayMetaDescription()
    {
        if (webBrowser1.Document != null) //the statement!
        {
          HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("META");
          foreach (HtmlElement elem in elems)
            {
              //Some loop-stuff you propably want to do
            }
        }
    }
