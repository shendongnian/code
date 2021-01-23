    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            Database.SetInitializer(new Initializer());
            using (var ctx = new Context())
            {
                // assert our findings that it is indeed not what we actually specified in the seed method, because of our Entity configuration with HasPrecision.
                Product product1 = ctx.Products.Find(1);
                Assert.AreEqual(145.244m, product1.Fineness);
                Product product2 = ctx.Products.Find(2);
                Assert.AreEqual(12.341m, product2.Fineness);
            }         
        }
    }
