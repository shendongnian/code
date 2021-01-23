    using (XmlReader reader = XmlReader.Create(new StringReader(str)))
                                {
                                    reader.ReadToFollowing("QuantityInIssueUnit");
    
                                    if (reader.Read())
                                    {
                                        // I want to get all the TEXT contents from the this node
                                        QuantityInIssueUnit_value = reader.Value;
    
                                    }
    
                                }
