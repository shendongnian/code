    foreach (XmlNode item1 in items)
                {
                    int currentIterationIndex = 0;
                    foreach (XmlNode node1 in item1.ChildNodes)
                    {
                        if(currentIterationIndex >= count -1)
                        {
                            continue; //or break; would probably be better.
                        }
                        if (node1.Name == "title")
                        {
                            rssDC.Title = node1.InnerText;
                        }
                        else if (node1.Name == "link")
                        {
                            rssDC.Link = node1.InnerText;
                        }
                        else if(node1.Name == "guid")
                        {
                            rssDC.RSS_ID = node1.InnerText;
                        }
                        else if (node1.Name == "description")
                        {
                            rssDC.Description = node1.InnerText;
                        }
                        else if (node1.Name == "pubDate")
                        {
                            rssDC.DatePublished = node1.InnerText;
                        }
    
                        currentIterationIndex += 1;
                    }
                    rssDC = RssBAL.AddRssFeed(rssDC);
    
    
                }
    
            }
