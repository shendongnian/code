    namespace MyNamespace
    {
        public partial class PublicClass
        {
            public int ReturnSomeStuff()
            {
                MyHelperClass1 tmp = new MyHelperClass1();
                MyHelperClass2 tmp2 = new MyHelperClass2();
    
                return tmp.GetValue1() + tmp2.GetValue2();
            }
        }
    }
