            // ITEM ADDED
            public override void ItemAdded(SPItemEventProperties properties)
            {
                base.ItemAdded(properties);
    
                try
                {
                    String curListName = properties.ListTitle;
                    if (_applicableLists.Contains(curListName))
                    {
                        
                        if (properties.ListItem.ContentType.Name == "Discussion")
                        {
                            
                            if (curListName == "Tasks")
                            {
                                SPList saList = properties.Web.Lists["Skills & Abilities"];
                                SPListItem saItem = SPUtility.CreateNewDiscussion(saList, properties.ListItem["Task Text"].ToString());
                                SPFieldLookupValue taskLookup = new SPFieldLookupValue();
                                taskLookup = new SPFieldLookupValue(properties.ListItem.ID, (string)properties.AfterProperties["Task ID"]);
                                saItem["Task Lookup"] = taskLookup;
                                saItem["Title"] = properties.ListItem["Task Text"].ToString();
                                saItem["Body"] = "Please leave a comment by clicking the Reply link on the right of this message.";
                                saItem[_inStatus] = "New";
                                // perform the update with event firing disabled
                                EventFiringEnabled = false;
                                saItem.Update();
                                EventFiringEnabled = true;
                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // handle exception...
                }
            }
