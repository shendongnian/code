                       var item = idnode.InnerXml;
    
                        XmlNodeList rwList = doc.SelectNodes(String.Format("data/row[@InventoryItemId='{0}']",item));
                        var rwCount = rwList.Count;
                        foreach (XmlNode rw in rwList)
                        {
                            XmlNodeList msList = id.SelectNodes("measures/measure");                        
                            foreach (XmlNode mes in msList)
                            {                            
                                XmlNode msnode = mes.SelectSingleNode("name");
                                {                                
                                    var attribute = doc.CreateAttribute("Measure");
                                    attribute.Value = msnode.InnerXml;
    
                                    if (rwCount > 0)
                                    {
                                        rw.Attributes.Append(attribute);
                                        rwCount--;
                                    }
                                    else
                                    {
                                        XmlNode clonenode = rw.Clone();
                                        clonenode.Attributes.Append(attribute);
                                        nd.AppendChild(clonenode);
                                    }
                                }
                            }
                        }
