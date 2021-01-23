    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var section = (MySection)ConfigurationManager.GetSection("mySection");
                Console.WriteLine(section.Enum);
            }
        }
        public class MySection : ConfigurationSection
        {
            [ConfigurationProperty("enum")]
            public MyEnum Enum
            {
                get { return (MyEnum)this["enum"]; }
                set { this["enum"] = value; }
            }
        }
        [Flags]
        public enum MyEnum
        {
            None = 0,
            Foo = 1,
            Bar = 2,
            Baz = 4
        }
    }
    <configSections>
      <section name="mySection" type="ConsoleApplication1.MySection, ConsoleApplication1"/>
    </configSections>
    <mySection enum="Foo, Bar"/>
