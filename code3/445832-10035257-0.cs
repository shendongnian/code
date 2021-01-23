    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
    
        public class CallbackTest
        {
            public CallbackTest(){}
                   
            private object _CallBack = null;
            
            public Func<T1, T2> GetCallBack<T1,T2>()
            {            
                    return (Func<T1, T2>)_CallBack;
            }
    
            public void SetCallBack<T1, T2>(Func<T1, T2> value)
            {
                _CallBack = value;
            }
    
    
           
        }
        class Program
        {
            static void Main(string[] args)
            {
    
                CallbackTest t = new CallbackTest();
                t.SetCallBack(new Func<int, int>(x => x * x));
    
                Console.WriteLine(t.GetCallBack<int, int>()(10));
    
                t.SetCallBack(new Func<string, string>(x => x.ToUpper()));
    
                Console.WriteLine(t.GetCallBack<string, string>()("test"));
    
                Console.ReadLine();
    
    
            }
        }
    }
