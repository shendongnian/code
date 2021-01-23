     class Program
        {
            static void Main(string[] args)
            {
                test objtest = new test();
                objtest.Name = "vikas";
                Test(ref objtest);
                //objtest = null; when I uncomment this line it shows me exception
                Console.WriteLine(objtest.Name);
                Console.ReadLine();
            }
    
            private static void Test(ref test objtest)
            {
                objtest.Name = "chetan";
                objtest = null;
            }
        }
    
        class test
        {
            private string _Name = string.Empty;
            public string Name
            {
                get
                {
                    return _Name;
                }
                set
                {
                    _Name = value;
                }
            }
        }
