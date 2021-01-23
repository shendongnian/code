    public Item[] Search(string searchterms)
            {
                var children = new List<Item>();
    
                var searchIndx = SearchManager.GetIndex(IndexName);
    
                using (var searchContext = searchIndx.CreateSearchContext())
                {
                    var ftQuery = new FullTextQuery(searchterms);
                    var hits = searchContext.Search(ftQuery);
                    var results = hits.FetchResults(0, hits.Length);
    
                    foreach (SearchResult result in results)
                    {
                        if (result.GetObject<Item>() != null)
                        {
                            //Regular sitecore item returned       
                            var resultItem = result.GetObject<Item>();
    
                            if (ParentItem == null)
                            {
                                children.Add(resultItem);
                            }
                            else if (resultItem.Publishing.IsPublishable(DateTime.Now, false) &&
                                     ItemUtilities.IsDecendantOfItem(ParentItem, resultItem))
                            {
                                children.Add(resultItem);
                            }
                        }
                    }
                }
                return children.ToArray();
            }
                                  
