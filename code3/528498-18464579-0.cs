    public void GetSiteMap(List<string> MyList)
    {
        /// Add namespace:
        ///using System.Xml;
        ///using System.Data;
        ///using System.Xml.Serialization;
        
        String MyHome = "http://www.mysite.com" ;//Create Absolute url start.
        // create DataSet and DataTable if needed, or use List Array only
       /*
            DataTable DT = new DataTable();
            foreach (var array in MyList)
            {
                DT.Rows.Add(array);
            }
        */
        XmlDocument doc = new XmlDocument();// create XML Documents
        XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);// Create the head element
        doc.AppendChild(dec);
        XmlElement root = doc.CreateElement("urlset");// Create the root element with attributes
        
        root.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        root.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
        root.SetAttribute("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
        doc.AppendChild(root);
        //foreach (DataRow DR in DT.Rows)// if use DataTable or
        foreach (var array in MyList)// if use List only
        {
            XmlElement MyUrl = doc.CreateElement("url");//create child node for root node
            XmlElement Loc = doc.CreateElement("loc");//create child node for MyUrl node
            XmlElement Freq = doc.CreateElement("changefreq");//create child node for MyUrl node
            XmlElement Pri = doc.CreateElement("priority");//create child node for MyUrl node
            
            Loc.InnerText = MyHome + "/" + array;//set value for 1. child node  Loc node
            Freq.InnerText = "daily";//set value for 1. child node-Freq node
            Pri.InnerText = "0.85";//set value for 1. child node-Pri node
            MyUrl.AppendChild(Loc); //add child Loc node to MyUrl node
            MyUrl.AppendChild(Freq);//add child Freq node to MyUrl node
            MyUrl.AppendChild(Pri);//add child Pri node to MyUrl node
            root.AppendChild(MyUrl);//add child MyUrl node to root node
        }
        Response.Clear();
        XmlSerializer xs = new XmlSerializer(typeof(XmlDocument));
        Response.ContentType = "text/xml";
        xs.Serialize(Response.Output, doc);
        Response.End();
    }
 
