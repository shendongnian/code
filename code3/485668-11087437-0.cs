    class Default 
    {
        public static readonly Default Instance = new Default();
        protected Default ()
        {
        }
        public static int DoFoo1() 
        { 
            //Do something 
        }
        public int Foo1 { get { return DoFoo1(); } }
        public static float DoVar2 
        { 
            //Do something 
        } 
        public float Var2 { get { return DoVar2(); } }
    } 
    class Other : Default
    {
        // Inherits Foo1 and Var2 automatically
    }
