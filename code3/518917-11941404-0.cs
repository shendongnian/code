    [TestFixture]
    public class ForTest
    {
        [Test]
        public void Test()
        {
            var root = XElement.Load("order.xml");
            var order = CreateOrder(root);
        }
        private Order CreateOrder(XElement element)
        {
            var result = new Order
            {
                Number = int.Parse(element.Element("Number").Value),
                 Date = DateTime.Parse(element.Element("Date").Value),
                Email = element.Element("Email").Value,
                Files = element.Descendants("File").Select(x => x.Value).ToList()
            };
            return result;
        }
    }
    public class Order
    {
        public int Number { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public List<string> Files { get; set; }
    }
