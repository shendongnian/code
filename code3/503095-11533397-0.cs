            public void Button_Click()
        {
            List<Order> ods = new List<Order>{new Order(){State="cali",ID=1},
                    new Order(){State="cali",ID=2},
                    new Order(){State="nali",ID=3},
                    new Order(){State="pali",ID=4},
                    new Order(){State="pali",ID=5},
            };
            List<Grouping> groups = new List<Grouping>();
            var orders = ods.GroupBy(g => g.State);
            foreach (var order in orders)
            {
                Grouping group = new Grouping() { State = order.Key, Orders = new List<Order>(), IDs = new List<int>() };
                order.ToList().ForEach(o => { group.Orders.Add(o); group.IDs.Add(o.ID); });
                groups.Add(group);
            }
        }
        public class Grouping
        {
            public string State { get; set; }
            public List<Order> Orders { get; set; }
            public List<int> IDs { get; set; }
        }
        public class Order
        {
            public string State
            {
                get;
                set;
            }
            public int ID
            {
                get;
                set;
            }
        }
