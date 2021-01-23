    public class Class1
    {
        public string Name { get; set; }
    }
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConvertTest()
        {
			var dictionary = new Dictionary<string, object>();
			var @class = new Class1 { Name = "Joe" };
			var propertyInfos = typeof (Class1).GetProperties();
			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
				dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(@class, BindingFlags.GetProperty, null, null, null));
			}
			var serializeObject = JsonConvert.SerializeObject(dictionary);
			var o = JsonConvert.SerializeObject(@class);
			Console.WriteLine(serializeObject);
			Console.WriteLine(o);
			var class1 = JsonConvert.DeserializeObject<Class1>(serializeObject);
			Console.WriteLine(class1.Name);
		}
	}
