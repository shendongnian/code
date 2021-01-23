    [TestFixture]
    public class NUnitClassTest
    {
        [Test]
        public void TestnUnitAsyncTest()
        {
            var number = GetNumberAsync(7);
            number.Wait();
            Assert.AreEqual("string is 6", number.Result);
        }
    
        public Task<string> GetNumberAsync(int n)
        {
            return Task.Run(() => "string is " + n);
        }
    }
