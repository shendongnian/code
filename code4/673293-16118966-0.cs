    abstract class ParameterBase
    {
        public void test()
        {
            string name = "testname";
            Console.WriteLine(name);
        }
    }
    
    class Parameter1 : ParameterBase
    {
        void getvalue()
        {
            Parameter1 pb = new Parameter1();
            pb.test();
        }        
    }  
