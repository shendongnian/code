        public interface ITestX
        {
            [XmlAttribute("NameX")]
            string PropertyNameX { get; set; }
        }
    
        public interface ITestY
        {
            [XmlAttribute("NameY")]
            string PropertyNameY { get; set; }
        }
    
        public interface ITestZ
        {
            [XmlAttribute("NameZ")]
            string PropertyNameZ { get; set; }
        }
    
        public abstract class TestC : ITestZ
        {
            public abstract string PropertyNameZ { get; set; }
        }
    
        public abstract class TestA : TestC, ITestX, ITestY
        {
            public abstract string PropertyNameX { get; set; }
            public abstract string PropertyNameY { get; set; }
        }
    
        public class TestB : TestA
        {
            public override string PropertyNameX { get; set; }
            public override string PropertyNameY  { get; set; }
            public override string PropertyNameZ { get; set; }
        }
    
        public static class ClassHandler
        {
            public static T GetCustomAttribute<T>(this PropertyInfo propertyInfo, bool inherit) where T : Attribute
            {
                object[] attributes = propertyInfo.GetCustomAttributes(typeof(T), inherit);
    
                return attributes == null || attributes.Length == 0 ? null : attributes[0] as T;
            }
    
            public static void GetXmlAttributeOverrides(XmlAttributeOverrides overrides, Type type)
            {
                if (type.BaseType != null)
                {
                    GetXmlAttributeOverrides(overrides, type.BaseType);
                }
    
                foreach (Type derived in type.GetInterfaces())
                {
                    foreach (PropertyInfo propertyInfo in derived.GetProperties())
                    {
                        XmlAttributeAttribute xmlAttributeAttribute = ClassHandler.GetCustomAttribute<XmlAttributeAttribute>(propertyInfo, true) as XmlAttributeAttribute;
    
                        if (xmlAttributeAttribute == null)
                            continue;
    
                        XmlAttributes attr1 = new XmlAttributes();
                        attr1.XmlAttribute = new XmlAttributeAttribute();
                        attr1.XmlAttribute.AttributeName = xmlAttributeAttribute.AttributeName;
                        overrides.Add(type, propertyInfo.Name, attr1);
                    }
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                XmlAttributeOverrides XmlAttributeOverrides = new XmlAttributeOverrides();
                ClassHandler.GetXmlAttributeOverrides(XmlAttributeOverrides, typeof(TestB));
                try
                {
                    TestB xtest = new TestB() { PropertyNameX = "RajX", PropertyNameY = "RajY", PropertyNameZ = "RajZ" };
    
                    StringBuilder xmlString = new StringBuilder();
                    using (XmlWriter xtw = XmlTextWriter.Create(xmlString))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(TestB), XmlAttributeOverrides);
                        serializer.Serialize(xtw, xtest);
    
                        xtw.Flush();
                    }
    
                    Console.WriteLine(xmlString.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
    }
