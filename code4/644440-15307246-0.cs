     foreach (var info in xdoc.Descendants(tns + "sign"))
            {
    if(info.Element(tns + "current-message").Value != "")
                    {
                    Items.Add(new ItemViewModel()
                        {
                            ID = i.ToString(),
                            LineOne = info.Element(tns + "direction").Value,
                            LineTwo = info.Element(tns + "current-message").Value,
                            LineThree = info.Element(tns + "name").Value
    
                        });
                    i++;
                    }
            }
