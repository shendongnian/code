    namespace AJack
    {
        [TestFixture]
        public class ParameterizedTestsDemo
        {
            private object[][] _inputs;
    
            public ParameterizedTestsDemo()
            {
                Console.Out.WriteLine("Instantiating test class instance");
                _inputs = new[]{ new object[]{1,2,3}, 
                                     new object[]{4,5,6} }; 
            }
    
            [TestFixtureSetUp]
            public void BeforeAllTests()
            {
                Console.Out.WriteLine("In TestFixtureSetup");
                object[] localVarDoesNotWork = {   new object[]{1,2,3}, 
                                        new object[]{4,5,6} };
                /*this will NOT work too
                _inputs = new[]{ new object[]{1,2,3}, 
                                     new object[]{4,5,6} }; */
            }
    
            [TestCaseSource("localVarDoesNotWork")]
            public  void WillNotRun(int x, int y, int z)
            {
                Console.Out.WriteLine("Inputs {0}, {1}, {2}", x,y,z);
            }
            [TestCaseSource("PropertiesFieldsAndMethodsWork")]
            public void TryThisInstead(int x, int y, int z)
            {
                Console.Out.WriteLine("Inputs {0}, {1}, {2}", x, y, z);
            }
            private object[] PropertiesFieldsAndMethodsWork
            {
                get {
                    Console.Out.WriteLine("Getting test input params");
                    
                    return _inputs;
                }
            }
        }
    }
