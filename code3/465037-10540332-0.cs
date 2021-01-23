    foreach (SyndicationElementExtension extension in f.ElementExtensions)
    {
        XElement element = extension.GetObject<XElement>();
    
        if (element.HasAttributes)
        {
            foreach (var attribute in element.Attributes())
            {
                string value = attribute.Value.ToLower();
                if (value.StartsWith("http://") && (value.EndsWith(".jpg") || value.EndsWith(".png") || value.EndsWith(".gif") ))
                {
                       rssItem.ImageLinks.Add(value); // Add here the image link to some array
                 }
            }                                
        }                            
    }
