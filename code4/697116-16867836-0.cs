    public class CantDeriveMe
    {
        private CantDeriveMe()
        {
        }
        public override string ToString()
        {
            return "My type is " + this.GetType().ToString();
        }
    }
    public class OhYeah : CantDeriveMe
    {
        static OhYeah CapturedInstance;
        ~OhYeah()
        {
            CapturedInstance = this;
        }
        OhYeah() : this(1/String.Empty.Length)
        {
        }
        OhYeah(int blah) : this()
        {
        }
        public static OhYeah Create()
        {
            try
            {
                new OhYeah(4);
            }
            catch (DivideByZeroException)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return CapturedInstance;
        }
        public static void test()
        {
            OhYeah it;
            it = OhYeah.Create();
            Console.WriteLine("Result was ({0})", it);
        }
    }
