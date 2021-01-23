    class Program {
        private class CustomerDto {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
        }
        private class ItemDto {
            public int ItemId { get; set; }
            public string ItemName { get; set; }
        }
        private class OrderDto {
            public int Id { get; set; }
            public int ItemId { get; set; }
            public int CustomerId { get; set; }
            public int Quantity { get; set; }
        }
        private class CustomerOrderDto {
            public int CustomerId { get; set; }
            public int ItemId { get; set; }
            public int TotalQuantity { get; set; }
        }
        static void Main(string[] args) {
            List<CustomerDto> Customers = new List<CustomerDto>() { 
                new CustomerDto() { CustomerId = 1, CustomerName = "one"},
                new CustomerDto() { CustomerId = 2, CustomerName = "two"},
                new CustomerDto() { CustomerId = 3, CustomerName = "three"}
            };
            List<ItemDto> Items = new List<ItemDto>() { 
                new ItemDto() { ItemId = 1, ItemName = "item one"},
                new ItemDto() { ItemId = 2, ItemName = "item two"},
                new ItemDto() { ItemId = 3, ItemName = "item three"}
            };
            // customer1 has 2 orders for item 1, 0 for item 2 or 3
            // customer2 has 1 order for item 2, 0 for item 1 or 3
            // customer3 has 1 order for item 2, 1 order for item 3 and 0 for item 1
            List<OrderDto> Orders = new List<OrderDto>() { 
                new OrderDto() { Id = 1, CustomerId = 1, ItemId = 1, Quantity = 3 },
                new OrderDto() { Id = 1, CustomerId = 1, ItemId = 1, Quantity = 5 },
                new OrderDto() { Id = 1, CustomerId = 3, ItemId = 2, Quantity = 5 },
                new OrderDto() { Id = 1, CustomerId = 3, ItemId = 3, Quantity = 5 },
                new OrderDto() { Id = 1, CustomerId = 2, ItemId = 2, Quantity = 5 }
            };
            List<CustomerOrderDto> results = (from c in Customers
                                              from i in Items
                                              join o in Orders on
                                                new { c.CustomerId, i.ItemId } equals
                                                new { o.CustomerId, o.ItemId } into oj
                                              from o in oj.DefaultIfEmpty()
                                              let x = o ?? new OrderDto() { CustomerId = c.CustomerId, ItemId = i.ItemId, Quantity = 0 }
                                              group x by new { x.CustomerId, x.ItemId } into g
                                              select new CustomerOrderDto() {
                                                  CustomerId = g.Key.CustomerId,
                                                  ItemId = g.Key.ItemId,
                                                  TotalQuantity = g.Select(x => x.Quantity).Sum()
                                              }
                                              ).ToList();
            foreach (var result in results) {
                Console.WriteLine("Customer {0} purchased {1} units of item {2}",
                    result.CustomerId, result.TotalQuantity, result.ItemId);
            }
            Console.ReadKey(true);
        }
    }
