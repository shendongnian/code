    if (imagegallery != null && imagegallery.DocumentNode != null)
    {
        HtmlNodeCollection linkColl = imagegallery.DocumentNode.SelectNodes("//a[@href]");
        if (linkColl != NULL)
        {
            foreach (HtmlNode link in linkColl)
            {
               //Do Something
            }
        }
    }
