    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var foo = new Foo() {Test = null};
            var settings = new JsonSerializerSettings
                               {
                                   ContractResolver = new SpecialContractResolver()
                               };
            Assert.AreEqual(
                JsonConvert.SerializeObject(foo, Formatting.None, settings), 
                "{\"Test\":0}"
            );
        }
    }
