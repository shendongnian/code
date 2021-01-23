    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestMyDllCLR
    {
        class Program
        {
            static void MyFunc(int i)
            {
                Console.WriteLine("Come on! {0}", i);
            }
    
            static void Main(string[] args)
            {
                MyDllCLR.Class.RegisterFunction1(MyFunc);
                MyDllCLR.Class.Caller1();
            }
        }
    }
