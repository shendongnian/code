    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;    
    namespace FunctionAssociatedPropertyFire {
        class Program {
            static void Main(string[] args) {
                new TestClass().Test();
                Console.ReadLine();
            }
        }
        class TestClass {
            public event Action ResponseReceived;
            private string response;    
            public string Response {
                get { return response; }    
                set {
                    response = value;
                    if (ResponseReceived != null) { ResponseReceived(); }
                }
            }
    
            void function_ResponseReceived() {
                Console.WriteLine("function_ResponseReceived");
            }
    
            public void Test() {
                ResponseReceived += new Action(function_ResponseReceived);
                Console.WriteLine("BeforeYes");
                Response = "yes";
                Console.WriteLine("AfterYes");
                Response = "no";
                Console.WriteLine("AfterNo");
            }
        }
    }
