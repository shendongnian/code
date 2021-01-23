    [WebMethod(MessageName = "GetItemsBeslist", Description = "Get a list of GAL shirts", CacheDuration = 3600)]
    public XmlDocument GetItemsBeslist()
    {
        if (bRegisterIP)
        {
           try { LogFiler.ToLog("### IP ### - [" + sRemoteAddress + "]"); }
           catch { }
        }
        
        try
        {
           var xProducts = GetProducts();
           string file = Server.MapPath("/bivolino3D/bivo/imgGal/ProductFeedBeslist.xml");
           using(XmlTextWriter textWriter = new XmlTextWriter(file, Encoding.UTF8))
           {
               textWriter.WriteStartDocument();
               xProducts.Save(textWriter);
               textWriter.WriteEndDocument();
               return xProducts;
           }
        }
        catch (Exception ex)
        {
           return ErrHandle("ERROR - GetItemsBeslist - " + ex.Message, "ERROR - GetItemsBeslist");
        }
    }
    private XmlDocument GetProducts()
    {
        XmlDocument xProducts = new XmlDocument();
        XmlElement subElm;
        XmlElement elmAttr;
        XmlNode elmValue;
        xProducts.CreateXmlDeclaration("1.0", "utf-8", null);
        XmlElement topElm = xProducts.CreateElement("ProductFeed");
        topElm.SetAttribute("version", "1.0");
        topElm.SetAttribute("timestamp", System.DateTime.Now.ToString().Replace(" ", ":"));
        xProducts.AppendChild(topElm);
        List<string[]> strarrVelden = new List<string[]>();
        strarrVelden.AddRange(DB.GetItemsBeslist());
        foreach (string[] rij in strarrVelden)
        {
           subElm = xProducts.CreateElement("Product");
           elmAttr = xProducts.CreateElement("ProductTitle");
           elmValue = xProducts.CreateNode(XmlNodeType.Text, "ProductTitle", null); elmValue.Value = "Herenoverhemd Bivolino " + rij[5].ToString();
           elmAttr.AppendChild(elmValue);
           subElm.AppendChild(elmAttr);
           elmAttr = xProducts.CreateElement("Price");
           elmValue = xProducts.CreateNode(XmlNodeType.Text, "Price", null); elmValue.Value = rij[6].ToString().Replace(",", ".");
           elmAttr.AppendChild(elmValue);
           subElm.AppendChild(elmAttr);
           elmAttr = xProducts.CreateElement("productURL");
           elmValue = xProducts.CreateNode(XmlNodeType.CDATA, "productURL", null); elmValue.Value = rij[1].ToString();
           elmAttr.AppendChild(elmValue);
           subElm.AppendChild(elmAttr);
           elmAttr = xProducts.CreateElement("Category");
           elmValue = xProducts.CreateNode(XmlNodeType.Text, "Category", null); elmValue.Value = "Herenoverhemd ";
           elmAttr.AppendChild(elmValue);
           subElm.AppendChild(elmAttr);
           elmAttr = xProducts.CreateElement("ProductDescription");
           elmValue = xProducts.CreateNode(XmlNodeType.Text, "ProductDescription", null); elmValue.Value = rij[2].ToString();
           elmAttr.AppendChild(elmValue);
           subElm.AppendChild(elmAttr);
           topElm.AppendChild(subElm);
        }
        
        return xProducts;
    }
