    public class Tester
    {
        [ParameterConverter(typeof(ParameterConverter), "TestConverter"] 
        public int Foo{get;set;}
        static object TestConverter(string val)
        {
          return 10;
        }
    }
