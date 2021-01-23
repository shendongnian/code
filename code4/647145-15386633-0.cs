    XmlDataDocument xmldoc = new XmlDataDocument();
                xmldoc.Load("C:/test.xml");
                var root = xmldoc.DocumentElement;
                if (root == null) return;
                var users = new List<User>();
    
                var tablenodes = root.SelectNodes("Table");
                if (tablenodes != null)
    
                    foreach (XmlNode nodes in tablenodes)
                    {
                        if (!nodes.HasChildNodes) continue;
    
                        if (nodes.Attributes == null) continue;
                        var user = new User { UserName = nodes.Attributes[0].Value };
                        var customer = new Customer();
    
                        var nodesdisplayname = nodes.SelectNodes("Column/displayname");
    
                        if (nodesdisplayname != null)
                        {
                            var xmlNode = nodesdisplayname.Item(0);
                            if (xmlNode != null)
                            {
                                customer.DisplayName  = xmlNode.InnerText;
                            }
                        }
    
                        var nodesorignalvalue = nodes.SelectNodes("Column/orignalvalue");
    
                        if (nodesorignalvalue != null)
                        {
                            var xmlNode = nodesorignalvalue.Item(0);
                            if (xmlNode != null)
                            {
                                customer.OriginalValue = xmlNode.InnerText;
                            }
                        }
                            
                        user.Customers = customer;
                        users.Add(user);
                    }
