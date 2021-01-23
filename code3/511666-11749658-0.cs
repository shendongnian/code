    public class jsonmenuwrapper
    {
        public user users { get; set; }
    }
    public class user
    {
        public String company { get; set; }
        public String contact_Number { get; set; }
    }
    [TestFixture]
    public class JsonTests
    {
        [Test]
        public void TestArrayDeserialization()
        {
            const string str =
    @"[{""users"":{""company"":""abc"",""contact_Number"":""999999999""}},
    {""users"":{""company"":""xyz"",""contact_Number"":""888888888""}},
    {""users"":{""company"":""xxx"",""contact_Number"":""555555555""}}]";
            var serializer = new JavaScriptSerializer();
            var data = serializer.Deserialize<List<jsonmenuwrapper>>(str);
            Assert.AreEqual(3, data.Count);
            Assert.AreEqual("abc", data[0].users.company);
            Assert.AreEqual("999999999", data[0].users.contact_Number);
            Assert.AreEqual("xyz", data[1].users.company);
            Assert.AreEqual("888888888", data[1].users.contact_Number);
            Assert.AreEqual("xxx", data[2].users.company);
            Assert.AreEqual("555555555", data[2].users.contact_Number);
        }
    }
