    XElement xel = XElement.Load(filePath);
    //you can even load the XML from a string/stream etc also....
    if (xel != null)
    {
        foreach (var mini in xel.Descendants("mini").ToList())
        {
            foreach (var album in mini.Descendants("Album").ToList())
            {
                string attrValue = album.Attribute("URI").Value;
                foreach (var predicate in mini.Descendants("predicate").ToList())
                {                          
                    string content = predicate.Value;
                }
            }
        }
    }
