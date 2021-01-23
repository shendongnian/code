    public class CTestIt : MarshalByRefObject
    {
        public static CTestIt Singleton;
        internal static void SetSingleton()
        { //This method is successfully executed before we start loading scripts
            Singleton = new CTestIt();
            Console.WriteLine("CTestIt Singleton set"); 
        }
        public static void test()
        {
           //Null reference when a script calls CSScriptTest.CTestIt.test();
            Singleton.test_member(); 
        }
        public void test_member()
        {
            Console.WriteLine("test");
        }
    }
