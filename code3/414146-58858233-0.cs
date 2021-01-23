    using System;
    
    namespace ConsoleApp1
    {
        class Class1
        {
            public enum MethodToCall
            {
                Method2,
                Method3
            }
    
            public delegate void MyDelegate(int number = 0, bool doThis = false, double longitude = 32.11);
    
            public static void DoThisFirst(int number, bool doThis, double longitude)
            {
                Console.WriteLine("DoThisFirst has been called.");
            }
    
            public static void DoSomethingElse(int number, bool doThis, double longitude)
            {
                Console.WriteLine("DoSomethingElse has been called.");
            }
    
            public static void DoAnotherThing(int number, bool doThis, double longitude)
            {
                Console.WriteLine("DoAnotherThing has been called.");
            }
    
            public static void Main()
            {
                void Action(MethodToCall methodToCall)
                {
                    MyDelegate myDel;
    
                    myDel = new MyDelegate(DoThisFirst);
    
                    switch (methodToCall)
                    {
                        case MethodToCall.Method2:
                            myDel += DoSomethingElse;
                            break;
                        case MethodToCall.Method3:
                            myDel += DoAnotherThing;
                            break;
                    }
    
                    myDel.Invoke();
                }
    
                Action(MethodToCall.Method3);
    
                Console.ReadKey();
            }
        }
    }
