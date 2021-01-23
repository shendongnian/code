    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading.Tasks;
    
    [TestClass]
    public class TestAsyncClass
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task TestGetIntAsync()
        {
            var obj = new AsyncClass();
            // How do I assert that an exception is thrown?
            var rslt = await obj.GetIntAsync();
        }
    }
