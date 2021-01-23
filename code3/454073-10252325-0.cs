 2. Casting or converting the xml element value to correct type on the line anyThingProperty.SetValue(obj, propertyElement.Value, null);
 
[TestClass]
public class SerializableInterfaceTest
{
    [TestMethod]
    public void TestMethod1()
    {
        string serialize = AnyThingSerializer.Serialize(
            new SerializableClass {Name = "test", Description = "test1", 
                AnyThing = new Animal {Name = "test", Color = "test1"}});
        Console.WriteLine(serialize);
        object obj = AnyThingSerializer.Deserialize<SerializableClass>(serialize);
    }
}
public sealed class SerializableClass
{
    public string Name { get; set; }
    public string Description { get; set; }
    [AnyThingSerializer]
    public object AnyThing { get; set; }
}
public static class AnyThingSerializer
{
    public static string Serialize(object obj)
    {
        Type type = obj.GetType();
        var stringBuilder = new StringBuilder();
        var serializer = new XmlSerializer(type);
        serializer.Serialize(new StringWriter(stringBuilder), obj);
        XDocument doc = XDocument.Load(new StringReader(stringBuilder.ToString()));
        foreach (XElement xElement in SerializeAnyThing(obj))
        {
            doc.Descendants().First().Add(xElement);
        }
        return doc.ToString();
    }
    public static object Deserialize<T>(string xml)
    {
        var serializer = new XmlSerializer(typeof (T));
        object obj = serializer.Deserialize(new StringReader(xml));
        XDocument doc = XDocument.Load(new StringReader(xml));
        DeserializeAnyThing(obj, doc.Descendants().OfType<XElement>().First());
        return obj;
    }
    private static void DeserializeAnyThing(object obj, XElement element)
    {
        IEnumerable<PropertyInfo> anyThingProperties = obj.GetType()
            .GetProperties().Where(p => p.GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == 
                    typeof (AnyThingSerializerAttribute)) != null);
        foreach (PropertyInfo anyThingProperty in anyThingProperties)
        {
            XElement propertyElement = element.Descendants().FirstOrDefault(e => 
                e.Name == anyThingProperty.Name && e.Attribute("type") != null);
            if (propertyElement == null) continue;
            Type type = Type.GetType(propertyElement.Attribute("type").Value);
            if (IsSimpleType(type))
            {
                anyThingProperty.SetValue(obj, propertyElement.Value, null);
            }
            else
            {
                object childObject = Activator.CreateInstance(type);
                DeserializeAnyThing(childObject, propertyElement);
                anyThingProperty.SetValue(obj, childObject, null);
            }
        }
    }
    private static List<XElement> SerializeAnyThing(object obj)
    {
        var doc = new List<XElement>();
        IEnumerable<PropertyInfo> anyThingProperties = 
            obj.GetType().GetProperties().Where(p => 
                p.GetCustomAttributes(true).FirstOrDefault(a => 
                    a.GetType() == typeof (AnyThingSerializerAttribute)) != null);
        foreach (PropertyInfo anyThingProperty in anyThingProperties)
        {
            doc.Add(CreateXml(anyThingProperty.Name, 
                anyThingProperty.GetValue(obj, null)));
        }
        return doc;
    }
    private static XElement CreateXml(string name, object obj)
    {
        var xElement = new XElement(name);
        Type type = obj.GetType();
        xElement.Add(new XAttribute("type", type.AssemblyQualifiedName));
        foreach (PropertyInfo propertyInfo in type.GetProperties())
        {
            object value = propertyInfo.GetValue(obj, null);
            if (IsSimpleType(propertyInfo.PropertyType))
            {
                xElement.Add(new XElement(propertyInfo.Name, value.ToString()));
            }
            else
            {
                xElement.Add(CreateXml(propertyInfo.Name, value));
            }
        }
        return xElement;
    }
    private static bool IsSimpleType(Type type)
    {
        return type.IsPrimitive || type == typeof (string);
    }
}
public class AnyThingSerializerAttribute : XmlIgnoreAttribute
{
}
