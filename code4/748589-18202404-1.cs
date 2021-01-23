    using System;
    using System.Reflection;
    
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldFixedLengthAttribute : Attribute
    {
        public int Length { get; set; }
    }
    
    public class Person
    {
        [FieldFixedLength(Length = 2)]
        public string fileprefix { get; set; }
    
        [FieldFixedLength(Length = 12)]
        public string customerName { get; set; }
    }
    
    public class Test
    {
        public static void Main()
        {
            foreach (var prop in typeof(Person).GetProperties())
            {
                var attrs = (FieldFixedLengthAttribute[])prop.GetCustomAttributes
                    (typeof(FieldFixedLengthAttribute), false);
                foreach (var attr in attrs)
                {
                    Console.WriteLine("{0}: {1}", prop.Name, attr.Length);
                }
            }
        }
    }
