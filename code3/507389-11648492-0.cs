    private void BindXML()
            {
                XmlDocument xmldoc = new XmlDocument(); 
    
              xmldoc.Load(Server.MapPath("~/App_Data/Werke.xml"));
    
              XmlNodeList nodes = xmldoc.GetElementsByTagName("Werk");
    
                foreach (XmlNode n in nodes)
                {
                    ListItem l = new ListItem();
                    l.Text = n.InnerXml.ToString();
                    dropWerk.Items.Add(l);
                }
    
                dropWerk.DataBind();
    
            }
