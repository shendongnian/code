    [TestFixture]
    public class DynamicObjects
    {
        [Test]
        public void Dynamic_Call()
        {
            dynamic obj1 = new Apple();
            obj1.Weight = 100;
            obj1.Color = "Red";
            dynamic obj2 = new Orange();
            obj2.Weight = 200;
            obj2.Width = 10;
            Assert.IsTrue(obj1.Weight < obj2.Weight);
        }
    }
    public class Apple
    {
        public int Weight { get; set; }
        public string Color { get; set; }
    }
    public class Orange
    {
        public int Weight { get; set; }
        public int Width { get; set; }
    }
