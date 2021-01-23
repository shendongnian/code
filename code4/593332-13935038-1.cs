            DateTime? lastCallDate = null;
            foreach (int id in allItems)
            {
                if (offered > 0 && itemsAdded != (offered * 3) && tDown)
                {
                    List<Inventory.Item> items = Trade.MyInventory.GetItemsByDefindex(id);
                    foreach (Inventory.Item item in items)
                    {
                        if (!Trade.myOfferedItems.ContainsValue(item.Id))
                        {
                            //execute if 3 seconds have passed since it last execution...
                            bool wasExecuted = false;
                            while (!wasExecuted)
                            {
                                if (lastCallDate == null || lastCallDate.Value.AddSeconds(3) < DateTime.Now)
                                {
                                    lastCallDate = DateTime.Now;
                                    if (Trade.AddItem(item.Id))
                                    {
                                        itemsAdded++;
                                        break;
                                    }
                                    wasExecuted = true;
                                }
                                System.Threading.Thread.Sleep(100);
                            }
                        }
                    }
                }
            }
