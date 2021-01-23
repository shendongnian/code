    [TestFixture]
    public class DynamicJson
    {
        [Test]
        public void Test()
        {
            dynamic flexible = new ExpandoObject();
            flexible.Int = 3;
            flexible.String = "hi";
            var dictionary = (IDictionary<string, object>)flexible;
            dictionary.Add("Bool", false);
            var serialized = JsonConvert.SerializeObject(dictionary); // {"Int":3,"String":"hi","Bool":false}
        }
    }
