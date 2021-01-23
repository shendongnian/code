    public class Parser
    {
        public Order ParseOrderFrom(XElement invoice)
        {
            string time = (string)invoice.Element("time");
            string date = (string)invoice.Element("date");
            return new Order {
               Id = (int)invoice.Element("order_id"),
               Date = DateTime.ParseExact(date + time, "dd-MM-yyyyhh:mm tt", null),
               Items = invoice.Element("order").Elements("item")
                              .Select(i => ParseOrderItemFrom(i)).ToList()
            };
        }
        public OrderItem ParseOrderItemFrom(XElement item)
        {
            var main = item.Element("Main");
           
            return new OrderItem {
                Id = (int)main.Element("id"),
                Quantity = (int)main.Element("Qty"),
                Extras = item.Element("Add").Elements("Extra")
                             .Select(e => ParseExtraFrom(e)).ToList()
            };
        }
        public Extra ParseExtraFrom(XElement extra)
        {
            return new Extra {
                Id = (int)extra.Attribute("id"),
                Quantity = (int)extra.Element("Qty"),
                Description = (string)extra.Element("Desc")
            };
        }
    }
