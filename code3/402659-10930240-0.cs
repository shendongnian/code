        // Open the XML doc  
        System.Xml.XmlDocument myXmlDocument = new System.Xml.XmlDocument();
        myXmlDocument.Load(Server.MapPath("InsertData.xml"));
        System.Xml.XmlNode myXmlNode = myXmlDocument.DocumentElement.FirstChild;
        // Create new XML element and populate its attributes  
        System.Xml.XmlElement myXmlElement = myXmlDocument.CreateElement("entry");
        myXmlElement.SetAttribute("Userid", Server.HtmlEncode(textUserid.Text));
        myXmlElement.SetAttribute("Username", Server.HtmlEncode(textUsername.Text));
        myXmlElement.SetAttribute("AccountNo", Server.HtmlEncode(txtAccountNo.Text));
        myXmlElement.SetAttribute("BillAmount", Server.HtmlEncode(txtBillAmount.Text));
  
        // Insert data into the XML doc and save  
        myXmlDocument.DocumentElement.InsertBefore(myXmlElement, myXmlNode);
        myXmlDocument.Save(Server.MapPath("InsertData.xml"));
        // Re-bind data since the doc has been added to  
        BindData();
        Response.Write(@"<script language='javascript'>alert('Record inserted Successfully Inside the XML File....')</script>");
        textUserid.Text = "";
        textUsername.Text = "";
        txtAccountNo.Text = "";
        txtBillAmount.Text = "";  
    }
    void BindData()
    {
        XmlTextReader myXmlReader = new XmlTextReader(Server.MapPath("InsertData.xml"));
        myXmlReader.Close();
    }  
