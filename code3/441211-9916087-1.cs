    public class MyReader : JsonTextReader
    {
        public MyReader(string s) : base(new StringReader(s))
        {
        }
        protected override void SetToken(JsonToken newToken, object value)
        {
            object retObj = value;
            if (retObj is long) retObj = Convert.ChangeType(retObj, typeof(int));
            if (retObj is double) retObj = Convert.ChangeType(retObj, typeof(decimal));
            base.SetToken(newToken, retObj);
        }
    }
    object[] variousTypes = new object[] { 3.14m, 10, "test" };
    string jsonString = JsonConvert.SerializeObject(variousTypes);
    JsonSerializer serializer = new JsonSerializer();
    var asObjectArray = serializer.Deserialize<object[]>(new MyReader(jsonString));
