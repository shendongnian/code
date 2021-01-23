    public abstract class BaseClass
    {
        public static int MyProperty { get; set; }
    }
    public class DerivedAlpha : BaseClass
    {
        public static new int MyProperty { get; set; }  // !! new int !!
    }
    public class DerivedBeta : BaseClass
    {
        public static new int MyProperty { get; set; } // !! new int !!
    }
            DerivedAlpha.MyProperty = 7;
            DerivedBeta.MyProperty = 8;
            BaseClass.MyProperty = 9;
