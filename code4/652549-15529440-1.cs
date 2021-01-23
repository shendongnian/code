    public static void updateStatus(string user, string file, string status)
    {
        XDocument doc = XDocument.Load(@"C:\Projects\ConsoleApp\XMLDocument.xml");
    
        var els = from item in doc.Descendants("dataModule")
                  where item.Descendants("DMC").First().Value == file
                  select item;
    
        if (els.Count() > 0)
        {
            XElement el = els.First();
            el.SetElementValue("status", status);
            el.SetElementValue("currentUser", user);
    
            doc.Save(@"C:\Projects\ConsoleApp\XMLDocument.xml");
        }
    }
