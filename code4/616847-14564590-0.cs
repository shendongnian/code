    class test
    {
        public String myString 
        { 
             get { return s; } 
             set { s = value; } 
        }
        private String s="World";
    }
    class modifier
    {
        public static void modify(test myTest)
        {
            myTest.myString += "_test";
        } 
    }
---
    test c = new test();
    modifier.modify(c);
    Console.WriteLine(c.myString); //World_test
