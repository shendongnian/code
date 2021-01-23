    using System;
    //using ... more stuff as necessary;
    
    public class MyClass
    {
        public MyClass()
        {
            // Unlike C++, fields are initialized to zero.
        }
        public MyClass(int n)
        {
             field = n;
        }
        public void method1(int n)
        {
             field = n;
        }
        public int method2()
        {
             return field;
        }
    
        private int field;
    };
    
