    public class Tests
        {
            [SetUp]
            public void Setup()
            {
            }
            
            [Test]
            public void Input1Test()
            {
                var items = new List<IItem> {
                    new Book("Book", 12.49M, 1, false),
                    new Other("Music CD", 14.99M, 1, false),
                    new Food("Chocolate Bar", 0.85M, 1, false)};
    
                var visitor = new ItemCostWithTaxVisitor();
    
                Assert.AreEqual(12.49, items[0].Accept(visitor));
                Assert.AreEqual(16.49, items[1].Accept(visitor));
                Assert.AreEqual(0.85, items[2].Accept(visitor));
            }
    
            [Test]
            public void Input2Test()
            {
                var items = new List<IItem> {
                    new Food("Bottle of Chocolates", 10.00M, 1, true),
                    new Other("Bottle of Perfume", 47.50M, 1, true)};
    
                var visitor = new ItemCostWithTaxVisitor();
    
                Assert.AreEqual(10.50, items[0].Accept(visitor));
                Assert.AreEqual(54.65, items[1].Accept(visitor));
            }
    
            [Test]
            public void Input3Test()
            {
                var items = new List<IItem> {
                    new Other("Bottle of Perfume", 27.99M, 1, true),
                    new Other("Bottle of Perfume", 18.99M, 1, false),
                    new Medicine("Packet of headache pills", 9.75M, 1, false),
                    new Food("Box of Chocolate", 11.25M, 1, true)};
    
                var visitor = new ItemCostWithTaxVisitor();
    
                Assert.AreEqual(32.19, items[0].Accept(visitor));
                Assert.AreEqual(20.89, items[1].Accept(visitor));
                Assert.AreEqual(9.75, items[2].Accept(visitor));
                Assert.AreEqual(11.80, items[3].Accept(visitor));
            }
        }
    
        public abstract class IItem : IItemVisitable
        { 
            public IItem(string name,
                decimal price,
                int quantity,
                bool isImported)
                {
                    Name = name;
                    Price = price;
                    Quantity = quantity;
                    IsImported = isImported;
                }
    
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public bool IsImported { get; set; }
    
            public abstract decimal Accept(IItemVisitor visitor);
        }
    
        public class Other : IItem, IItemVisitable
        {
            public Other(string name, decimal price, int quantity, bool isImported) : base(name, price, quantity, isImported)
            {
            }
    
            public override decimal Accept(IItemVisitor visitor) => Math.Round(visitor.Visit(this), 2);
        }
    
        public class Book : IItem, IItemVisitable
        {
            public Book(string name, decimal price, int quantity, bool isImported) : base(name, price, quantity, isImported)
            {
            }
    
            public override decimal Accept(IItemVisitor visitor) => Math.Round(visitor.Visit(this),2);
        }
    
        public class Food : IItem, IItemVisitable
        {
            public Food(string name, decimal price, int quantity, bool isImported) : base(name, price, quantity, isImported)
            {
            }
    
            public override decimal Accept(IItemVisitor visitor) => Math.Round(visitor.Visit(this), 2);
        }
    
        public class Medicine : IItem, IItemVisitable
        {
            public Medicine(string name, decimal price, int quantity, bool isImported) : base(name, price, quantity, isImported)
            {
            }
    
            public override decimal Accept(IItemVisitor visitor) => Math.Round(visitor.Visit(this), 2);
        }
    
        public interface IItemVisitable
        {
            decimal Accept(IItemVisitor visitor);
        }
    
        public class ItemCostWithTaxVisitor : IItemVisitor
        {
            public decimal Visit(Food item) => CalculateCostWithTax(item);
    
            public decimal Visit(Book item) => CalculateCostWithTax(item);
    
            public decimal Visit(Medicine item) => CalculateCostWithTax(item);
    
            public decimal CalculateCostWithTax(IItem item) => item.IsImported ?
                Math.Round(item.Price * item.Quantity * .05M * 20.0M, MidpointRounding.AwayFromZero) / 20.0M + (item.Price * item.Quantity)
                : item.Price * item.Quantity;
                   
            public decimal Visit(Other item) => item.IsImported ?
                Math.Round(item.Price * item.Quantity * .15M * 20.0M, MidpointRounding.AwayFromZero) / 20.0M + (item.Price * item.Quantity)
                : Math.Round(item.Price * item.Quantity * .10M * 20.0M, MidpointRounding.AwayFromZero) / 20.0M + (item.Price * item.Quantity);
        }
    
        public interface IItemVisitor
        {
            decimal Visit(Food item);
            decimal Visit(Book item);
            decimal Visit(Medicine item);
            decimal Visit(Other item);
        }
