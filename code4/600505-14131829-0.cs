    namespace A
    {
        class DebugHelper
        {
            public void LogMethodName()
            {
                var method = new StackFrame(1).GetMethod();
                Console.WriteLine("inside {0}.{1}", method.DeclaringType, method.Name);
            }
        }
        class A1
        {
            void f1()
            {
                LogMethodName();  //1
            }
            void f2()
            {
                LogMethodName();  //2
            }
        }
     }
