    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                var data = GetData();
    
                var firts = data.First();
    
                var info = firts.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).First(p => p.Name == "Name");
                var value = info.GetValue(firts);
    
                Assert.AreEqual(value, "One");
            }
    
    
            [TestMethod]
            public void TestMethod2()
            {
                var data = GetData();
    
                var config = new MapperConfiguration(cfg => cfg.CreateMissingTypeMaps = true);
                var mapper = config.CreateMapper();
    
                var users = data.Select(mapper.Map<User>).ToArray();
    
                var firts = users.First();
    
                Assert.AreEqual(firts.Name, "One");
    
            }
    
            [TestMethod]
            public void TestMethod3()
            {
                var data = GetJData();
    
    
                var users = JsonConvert.DeserializeObject<User[]>(data);
    
                var firts = users.First();
    
                Assert.AreEqual(firts.Name, "One");
    
            }
    
            private object[] GetData()
            {
    
                return new[] { new { Id = 1, Name = "One" }, new { Id = 2, Name = "Two" } };
            }
    
            private string GetJData()
            {
    
                return JsonConvert.SerializeObject(new []{ new { Id = 1, Name = "One" }, new { Id = 2, Name = "Two" } }, Formatting.None);
            }
    
            public class User
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
        }
    
    }
