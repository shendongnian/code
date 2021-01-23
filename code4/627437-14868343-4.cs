    public class EnumTest : Attribute
    {
        public Enum enum;
    
        public EnumTest(object e)
        {
            enum = e as Enum;
        }
    }
