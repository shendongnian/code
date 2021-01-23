    public class Order
    {
        public static Order CreateFrom(XElement invoice)
        {
            string time = (string)invoice.Element("time");
            string date = (string)invoice.Element("date");
            return new Order {
                Id = (int)invoice.Element("order_id"),
                Date = DateTime.ParseExact(date + time, "dd-MM-yyyyhh:mm tt", null),
                Items = invoice.Element("order")
                               .Elements("item")
                               .Select(i => OrderItem.CreateFrom(i))
                               .ToList()
            };
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItem> Items { get; set; }
    }
