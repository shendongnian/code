    // Since there are different types of items, we need an interface/abstact
    // class to pivot.
    public interface Item {
    }
    // The information neccesary for storing the 'Extra' element.
    public class Extra {
        public Int32 ID { get; private set; }
        public Int32 Quantity { get; private set; }
        public String Description { get; private set; }
        public Extra(XElement extra) {
            // Here we load up all of the details from the 'extra' element
            this.ID = Int32.Parse(extra.Attribute("id").Value);
            this.Quantity = Int32.Parse(extra.Element("Qty").Value); ;
            this.Description = extra.Element("Desc").Value;
        }
    }
    // The 'add-item' is associated with the 'add' tag in the actual XML.
    public class AddItem : Item {
        public IEnumerable<Extra> Extras { get; private set; }
        // The 'extras' is a collection of many items, so we require
        // an ienumerable.
        public AddItem(IEnumerable<Extra> extras) {
            this.Extras = extras;
        }
    }
    // The storage for the 'main-item'
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
                .Select(invoice => new {
                    // Project the main details of the invoice { OrderID, Time, Date, Order }
                    // The order itself needs to be projected again though because it too is a 
                    // collection of sub items.
                    OrderID = invoice.Element("order_id").Value,
                    Time = invoice.Element("time").Value,
                    Date = invoice.Element("date").Value,
                    Order = invoice.Element("order")
                        .Elements()
                        .Elements()
                        .Select(item => {
                            // First, we need to know what type of item this 'order' is.
                            String itemType = item.Name.ToString();
                            // If its a 'main' item, then return that type.
                            if (itemType == "Main") {
                                Int32 id = Int32.Parse(item.Element("id").Value);
                                Int32 quantity = Int32.Parse(item.Element("Qty").Value);
                                return (Item)new MainItem(id, quantity);
                            }
                            // If it's an 'Add' item. Then we have to:
                            if (itemType == "Add") {
                                // (1) Capture all of the extras.
                                IEnumerable<Extra> extras = item.Elements()
                                    .Select(extra => new Extra(extra))
                                    .ToList();
                                // (2) Add the extras to a new AddItem. Then return the 'add'-item.
                                // Notice that we have to cast to 'Item' because we are returning 
                                // a 'Main'-item sometimes and an 'add' item other times.
                                // Select requires the return type to be the same regardless.
                                return (Item)new AddItem(extras);
                            }
                            // Hopefully this path never hits.
                            throw new NotImplementedException("This path not defined");
                        }).ToList()
                }).ToList();
            Console.WriteLine(projection);
        }
    }
