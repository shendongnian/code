                // via https://msdn.microsoft.com/en-us/library/office/dn592093(v=exchg.150).aspx
                int pageSize = 100;
                int offset = 0;
                ItemView view = new ItemView(pageSize + 1, offset);
                view.PropertySet = new PropertySet(ItemSchema.Subject, ItemSchema.DateTimeSent);
                view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending);
                view.Traversal = ItemTraversal.Shallow;
                bool moreItems = true;
                ItemId anchorId = null;
                while (moreItems)
                {
                    FindItemsResults<Item> results = service.FindItems(buildsFolderId, view);
                    moreItems = results.MoreAvailable;
                    if (moreItems && anchorId != null)
                    {
                        // Check the first result to make sure it matches
                        // the last result (anchor) from the previous page.
                        // If it doesn't, that means that something was added
                        // or deleted since you started the search.
                        if (results.Items.First<Item>().Id != anchorId)
                        {
                            Console.Error.WriteLine("The collection has changed while paging. Some results may be missed.");
                        }
                    }
                    if (moreItems)
                    {
                        view.Offset += pageSize;
                    }
                    anchorId = results.Items.Last<Item>().Id;
                    // Because you’re including an additional item on the end of your results
                    // as an anchor, you don't want to display it.
                    // Set the number to loop as the smaller value between
                    // the number of items in the collection and the page size.
                    int displayCount = results.Items.Count > pageSize ? pageSize : results.Items.Count;
                    for (int i = 0; i < displayCount; i++)
                    {
                        Item item = results.Items[i];
                        Console.WriteLine("[" + item.DateTimeSent + "] " + item.Subject);
                    }
                    Console.Error.WriteLine("Current offset: {0}/{1}", view.Offset, folder.TotalCount);
                }
