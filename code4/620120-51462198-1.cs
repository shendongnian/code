    wfo = XElement.Load("some xml");
    foreach (var element in wfo.DescendantsAndSelf())
                        {
                                foreach (XAttribute attribute in element.Attributes())
                                {
                                    if (attribute.Value.Any(q=>q== "search"))
                                    {
                                        
                                    }
                                }
                            }
                        }
