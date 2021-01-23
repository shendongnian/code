    XElement xel = XElement.Load(filePath);
    //you can even load the XML from a string/stream etc also....
    if (xel != null)
    {
        foreach (var mini in xel.Elements("mini"))
        {
            foreach (var album in mini.Elements("Album"))
            {
                string attrValue = album.Attribute("URI").Value;
                foreach (var predicate in album.Elements("predicate"))
                {                          
                    string content = predicate.Value;
                }
            }
        }
    }
