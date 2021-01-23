    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var foo = new Foo();
            var settings = new JsonSerializerSettings { ContractResolver = new SpecialContractResolver() };
            Assert.AreEqual(
                JsonConvert.SerializeObject(foo, Formatting.None, settings), 
                "{\"IntField\":0,\"Int\":0,\"Boolean\":false}");
        }
    }
