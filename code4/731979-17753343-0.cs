    public abstract class Item {
    }
    public class Extra {
        public Int32 ID { get; private set; }
        public Int32 Quantity { get; private set; }
        public String Description { get; private set; }
        public Extra(XElement extra) {
            this.ID = Int32.Parse(extra.Attribute("id").Value);
            this.Quantity = Int32.Parse(extra.Element("Qty").Value); ;
            this.Description = extra.Element("Desc").Value;
        }
    }
    public class AddItem : Item {
        public IEnumerable<Extra> Extras { get; private set; }
        // Default for the empty types
        public AddItem(IEnumerable<Extra> extras) {
            this.Extras = extras;
        }
    }
    public class MainItem : Item {
        public Int32 ID { get; private set; }
        public Int32 Quantity { get; private set; }
        public MainItem(Int32 id, Int32 quantity) {
            this.ID = id;
            this.Quantity = quantity;
        }
    }
    class Program {
        static void Main(string[] args) {
            String data = File.ReadAllText("File.txt");
            XElement tree = XElement.Parse(data);
            var projection = tree.Elements()
                .Select(invoice =>
                    new {
                        OrderID = invoice.Element("order_id").Value,
                        Time = invoice.Element("time").Value,
                        Date = invoice.Element("date").Value,
                        Order = invoice.Element("order")
                            .Elements()
                            .Elements()
                            .Select(item => {
                                String itemType = item.Name.ToString();
                                if (itemType == "Main") {
                                    Int32 id = Int32.Parse(item.Element("id").Value);
                                    Int32 quantity = Int32.Parse(item.Element("id").Value);
                                    return (Item)new MainItem(id, quantity);
                                }
                                if (itemType == "Add") {
                                    IEnumerable<Extra> extras = item.Elements()
                                        .Select(extra => new Extra(extra))
                                        .ToList();
                                    return (Item)new AddItem(extras);
                                }
                                throw new NotImplementedException("This path not defined");
                            }).ToList()
                    }).ToList();
            Console.WriteLine(projection);
        }
    }
