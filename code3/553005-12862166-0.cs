    private void xmlBuild()
    {
        XElement documentElement = new XElement(ns+"Document");
        XDocument doc = new XDocument(
        new XDeclaration("1.0", "utf-8", ""),
        new XComment("This is comment by me"),
        new XElement(ns+"kml"), documentElement);      
        for(int i =0; i < 2; i++)
        {
            documentElement.add(rec_build());
        }
        doc.Save(Server.MapPath(@"~\App_Data\markers2.xml"));
    }
    private XElement rec_build()
    {
        if (iteration != 0)
        {
            iteration -= 1;
            return final_rec = new XElement(ns + "Placemark",
                    new XAttribute("id", "1"),
                    new XElement(ns + "title", "something"),
                    new XElement(ns + "description", "something"),
                    new XElement(ns + "LookAt",
                    new XElement(ns + "Longitude", "49.69"),
                    new XElement(ns + "Latitude", "32.345")), 
                    new XElement(ns + "Point", 
                    new XElement(ns + "coordinates", "49.69,32.345,0")));
        }
        else
        {
            return null;
        }
    }
