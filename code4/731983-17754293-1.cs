    public class OrderItem
    {
        public static OrderItem CreateFrom(XElement item)
        {
            var main = item.Element("Main");
            var extra = item.Element("Add").Element("Extra");  
            return new OrderItem {
                Id = (int)main.Element("id"),
                Quantity = (int)main.Element("Qty"),
                Extras = extra == null ? null : Extras.CreatFrom(extra)
            };
        }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Extras Extras { get; set; }
    }
