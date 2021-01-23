    class Program
    {
        static void Main(string[] args)
        {
            var myItems = new List<WorkOrderItem>
            {
                new WorkOrderItem { OrderId = 1, ItemName = "A", ItemQuantity = 0 },
                new WorkOrderItem { OrderId = 0, ItemName = "A", ItemQuantity = 1 },
                new WorkOrderItem { OrderId = 0, ItemName = "A", ItemQuantity = 2 },
                new WorkOrderItem { OrderId = 0, ItemName = "B", ItemQuantity = 3 },
                new WorkOrderItem { OrderId = 0, ItemName = "B", ItemQuantity = 4 },
                new WorkOrderItem { OrderId = 1, ItemName = "B", ItemQuantity = 5 },
                new WorkOrderItem { OrderId = 0, ItemName = "C", ItemQuantity = 6 },
            };
    
            int myId = 0;
    
            List<WorkOrderItem> groupedItems =
                myItems.Where(i => i.OrderId == myId)
                        .GroupBy(
                            //key selector
                            i => i.ItemName,
                            //result selector
                            (name, items) =>
                            {
                                var aggregatedItem = new WorkOrderItem
                                {
                                    OrderId = myId,
                                    ItemName = name,
                                    ItemQuantity = items.Sum(i => i.ItemQuantity)
                                };
                                return aggregatedItem;
                            })
                            .ToList();
    
    
        }
    
        class WorkOrderItem
        {
            public int OrderId { get; set; }
            public string ItemName { get; set; }
            public int ItemQuantity { get; set; }
        }
    }
