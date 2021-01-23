        public void ValidateXml(string[] Arrays)
        {                                         
            foreach (var item in Arrays)
            {
                Xdoc.Load(item);                              
                XmlNodeList xnList = Xdoc.SelectNodes("FirstParentNode");
                if (xnList.Count > 0)
                {
                    foreach (XmlNode xn in xnList)
                    {
                        XmlNodeList anode = xn.SelectNodes("SecondParentNode");
                        if (anode.Count > 0)
                        {
                            foreach (XmlNode bnode in anode)
                            {                               
                                string InnerNodeOne = bnode["InnerNode1"].InnerText;
                                string InnerNodeTwo = bnode["InnerNode1"].InnerText;
                                                                                    
                            }                           
                        }
                        else
                        {
                            ErrorLog("Parent Node DoesNot Exists");                                                 
                        }
                    }                  
                }
                else
                {
                    ErrorLog("Parent Node DoesNot Exists");
                }
               
            }
           //then insert or update these values in database here
        }
