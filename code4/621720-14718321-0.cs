    using System;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string propName = FindPropertyNameByXmlElementAttributeElementName(typeof (MyClass), "Foo");
    
                Console.WriteLine(propName);
                Console.ReadKey();
            }
            static string FindPropertyNameByXmlElementAttributeElementName(Type type, string elementName)
            {
                PropertyInfo propertyInfo = 
                    type.GetProperties().SingleOrDefault(
                            prop => prop.HasAttributeWithValue<XmlElementAttribute>(
                                    a => a.ElementName == elementName
                                )
                        );
                if (propertyInfo == null)
                {
                    return "NOT FOUND";
                }
                return propertyInfo.Name;
            }
        }
    
        public static class PropertyInfoExtensions
        {
            public static bool HasAttributeWithValue<TAttribute>(this PropertyInfo pi, Func<TAttribute, bool> hasValue)
            {
                TAttribute attribute = 
                    (TAttribute)pi.GetCustomAttributes(typeof(TAttribute), true).SingleOrDefault();
                if (attribute == null)
                {
                    return false;
                }
                return hasValue(attribute);
            }
        }
        class MyClass
        {
            [XmlElement(ElementName = "Foo", Form = XmlSchemaForm.None)]
            public string Rumplestiltskin { get; set; }
        }
    }
