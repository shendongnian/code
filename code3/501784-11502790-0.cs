    using NUnit.Framework;
    
    namespace Project.Tests
    {
        [TestFixture(1)] 
        [TestFixture(2)]
        public class MyTest
        {
            private int _intType;
    
             public MyTest(int type)
             {
                 _intType = type;
             }
            
            [SetUp]
            public void Setup()
            {
                if (_intType==1)
                {
                    //Mock Return false
                }
                else
                {
                    //Mock Return Value
                }
            }
        }
    }
