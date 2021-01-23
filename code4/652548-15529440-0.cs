    public static void updateStatus(string user, string file, string status)
    {
        XDocument doc = XDocument.Load(@"C:\Projects\ConsoleApp\XMLDocument.xml");
    
        var el = (from item in doc.Descendants("dataModule")
                    where item.Descendants("DMC").First().Value == file
                    select item).First();
    
        if (el != null)
        {
            el.SetElementValue("status", status);
            el.SetElementValue("currentUser", user);
        }
    
        doc.Save(@"C:\Projects\ConsoleApp\XMLDocument.xml");
    }
