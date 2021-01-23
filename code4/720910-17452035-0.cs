    using System;
    using System.ComponentModel;
    using System.Globalization;
    
    public enum DemoEnum
    {
        Foo,
        Bar,
        [Description("This is a baz")]
        Baz
    }
    
    class Test
    {
        static void Main()
        {
            foreach (var name in Enum.GetNames(typeof(DemoEnum)))
            {
                var field = typeof(DemoEnum).GetField(name);
                Console.WriteLine("{0}: {1}", name,
                                  field.IsDefined(typeof(DescriptionAttribute),
                                                  false));
            }
        }
    }
