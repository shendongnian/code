    using System;
    using System.Runtime.InteropServices;
    namespace MyDLL
    {
       [ComVisible(true)]
       public class Operations
       {
           [ComVisible(true)]
           public int AddIntegers(int a, int b)
           {
               return a + b;
           }
        }
    }
