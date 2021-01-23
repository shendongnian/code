    for (int sp_range = int.Parse(myParser.GetKey("SP_Range")); sp_range < int.Parse(myParser.GetKey("EP_Range")); sp_range++)
    {
        cboPort.Items.Add(sp_range.ToString()); //Adds the load of values
        foreach (XElement xml in main.XPathSelectElements("/Row/ip_addresses"))
        {
            xml.SetAttributeValue("id", sp_range++);//You have to re-iterate for the set# Nodes
        }
               
    }
    main.Save(xmlpath);
