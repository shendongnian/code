    public class DerivedStringEnum : StringEnum
    {
        // Other members as before.
        
        static DerivedStringEnum()
        {
        }
        
        public static void ForceInit()
        {
        }
    }
        
    class Test
    {
        static void Main()
        {
            string s = "EnumValue1";
            DerivedStringEnum.ForceInit();
            DerivedStringEnum e = (DerivedStringEnum) s;
            Console.WriteLine(e); // EnumValue1
        }
    }
