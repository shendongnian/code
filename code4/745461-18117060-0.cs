    public abstract class BaseClass{ }
    [XmlRoot("One")]
    public class ChildOne : BaseClass {}
    [XmlRoot("Two")]
    public class ChildTwo : BaseClass { }
    class Program
    {
        private static void Main(string[] args)
        {
            var known = new Type[] {typeof (ChildOne), typeof (ChildTwo)};
            var obj1 = Deserialize<BaseClass>(@"<?xml version=""1.0""?><One></One>", known);
            var obj2 = Deserialize<BaseClass>(@"<?xml version=""1.0""?><Two></Two>", known);
        }
        private static T Deserialize<T>(string xml, Type[] knownTypes)
        {
            Type rootType = typeof (T);
            if (knownTypes.Any())
            {
                using (var reader = XmlReader.Create(new StringReader(xml)))
                {
                    reader.MoveToContent();
                    rootType = (from kt in knownTypes
                            let xmlRoot = kt.GetCustomAttributes<XmlRootAttribute>().FirstOrDefault()
                            where kt.Name == reader.Name || (xmlRoot != null && xmlRoot.ElementName == reader.Name)
                            select kt).FirstOrDefault() ?? typeof(T);
                }
            }
            return (T) new XmlSerializer(rootType, knownTypes).Deserialize(new StringReader(xml));
        }
    }
