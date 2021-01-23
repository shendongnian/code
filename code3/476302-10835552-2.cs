    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
    public class FooAttribute : Attribute
    {
        private String description;
        public FooAttribute(String description)
        {
            this.description = description;
        }
        public String Description
        {
            get
            {
                return this.description;
            }
        }
    }
    class FooClass
    {
        private int fooProperty = 42;
        [Foo("Foo attribute description")]
        public int FooProperty
        {
            get
            {
                return this.fooProperty;
            }
        }
        public static String GetPropertyNameByCustomAttributeName(String customAttributeName)
        {
            System.Reflection.PropertyInfo[] propertyInfos;
            propertyInfos = typeof(FooClass).GetProperties();
            foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
            {
                Object[] customAttributes = propertyInfo.GetCustomAttributes(true);
                if (customAttributes.Length > 0)
                {
                    foreach (Object customAttribute in customAttributes)
                    {
                        if (customAttribute.ToString() == customAttributeName.ToString())
                        {
                            return propertyInfo.Name;
                        }
                    }
                }
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            String propertyName = FooClass.GetPropertyNameByCustomAttributeName("ConsoleApplication1.FooAttribute");
            if (propertyName == null)
            {
                System.Console.WriteLine("No property name for this custom attribute");
            }
            else
            {
                System.Console.WriteLine(propertyName);
            }
            
            System.Console.ReadLine();
        }
    }
    }
