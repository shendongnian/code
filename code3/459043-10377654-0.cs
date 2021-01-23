    public interface ITest
    {
        [XmlAttribute("Name")]
        string PropertyName { get; set; }
    }
    
    public class XTest : ITest
    {
        public string PropertyName
        {
            get;
            set;
        }
    }
    
    public class Program
    {
       static void Main(string[] args)
        {
    
            try
            {
                XTest xtest = new XTest() { PropertyName = "Raj" };
    
                StringBuilder xmlString = new StringBuilder();
                using (XmlWriter xtw = XmlTextWriter.Create(xmlString))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(XTest), GetXmlAttributeOverrides(typeof(XTest)));
                    serializer.Serialize(xtw, xtest);
    
                    xtw.Flush();
                }
    
                Console.WriteLine( xmlString.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    
       public static XmlAttributeOverrides GetXmlAttributeOverrides(Type derivedType)
       {
           Type type = typeof(ITest);
           XmlAttributeOverrides overrides = new XmlAttributeOverrides();
    
           XmlAttributes attr = new XmlAttributes();
    
           foreach (PropertyInfo propertyInfo in type.GetProperties())
           {
               XmlAttributeAttribute xmlAttributeAttribute = propertyInfo.GetCustomAttribute(typeof(XmlAttributeAttribute), true) as XmlAttributeAttribute;
    
               if (xmlAttributeAttribute == null) continue;
    
               XmlAttributes attr1 = new XmlAttributes();
               attr1.XmlAttribute = new XmlAttributeAttribute();
               attr1.XmlAttribute.AttributeName = xmlAttributeAttribute.AttributeName;
               overrides.Add(derivedType, propertyInfo.Name, attr1);
           }
    
           return overrides;
       }
    }
