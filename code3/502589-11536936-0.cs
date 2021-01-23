    using (XmlReader reader = XmlReader.Create(new StringReader(str)))
                                {
                                    //UOM
                                    reader.ReadToFollowing("QuantityInIssueUnit");
                                    reader.MoveToFirstAttribute();
                                    string value = reader.Value;
                                    QuantityInIssueUnit_uom = value;  
                                }
