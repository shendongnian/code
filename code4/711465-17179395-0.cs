    using System;
    
    [Serializable]
    public class MyCustomClass
    {
        public bool prop1 { get; set; }
        public Nullable<Guid> prop2 { get; set; }
        public string prop3 { get; set; }
    }
    using System.Globalization;
    using System.IO;
    using System.Xml.Serialization;
    public static class MySerializer
    {
        public static string SerializeToXml<T>(this T value)
        {
            var writer = new StringWriter(CultureInfo.InvariantCulture);
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, value);
            return writer.ToString();
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var myCustomClasses = new List<MyCustomClass>();
            myCustomClasses.Add(new MyCustomClass { prop1 = true, prop2 = Guid.NewGuid(), prop3 = "Testing" });
            myCustomClasses.Add(new MyCustomClass { prop1 = true, prop2 = null, prop3 = "Testing2" });
            var serialized = MySerializer.SerializeToXml(myCustomClasses);
            Assert.IsNotNull(serialized);
        }
    }
