    public class TestClass
    {
        public static explicit operator int(TestClass d)
        {
            return 1;
        }
    }
    
    var testClass = new TestClass();
    object obj = testClass;
    var value = (int)testClass;//No exceptions here, because the CLR knows how to cast TestClass to int.
    var i = (int)obj;//Exception here, because the CLR doesn't know how to cast object to int.
