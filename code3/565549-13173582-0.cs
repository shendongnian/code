    [TestFixture]
    public class GoldCardTests
    {
        [TestCase(2000, 1, 2000 * 0.03)]
        [TestCase(2500, 1, 2000 * 0.04)]
        public void TestNameTest(double balance, int year, double expected)
        {
            var goldCard = new GoldCard("", "", balance, year);
            double calcCouponValue = goldCard.CalcCouponValue();
            Assert.AreEqual(expected,calcCouponValue);
        }
    }
    
    public class GoldCard : Card
    {
        public GoldCard(string id, string name, double balance, int year)
            : base(id, name, balance)
        {
            this.Year = year;
        }
    
        public int Year { get; set; }
    
        public double CalcCouponValue()
        {
            double rate = 0;
            if (Balance < 2500)
            {
                rate = 0.03*Balance;
            }
            else if (Balance > 2500 && Year < 2)
            {
                rate = 0.04*Balance;
            }
            else if (Balance > 2500 && Year > 2)
            {
                rate = 0.05*Balance;
            }
            return rate;
    
        }
    }
    
    public class Card
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    
        protected Card(string id, string name, double balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }
    }
