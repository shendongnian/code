    namespace A
    {
        public static class DebugHelper
        {
            [Conditional("DEBUG")]
            public static void LogMethodName()
            {
                var method = new StackFrame(1).GetMethod();
                Console.WriteLine("inside {0}.{1}", method.DeclaringType, method.Name);
            }
        }
        class A1
        {
            void f1()
            {
                DebugHelper.LogMethodName();  //1
            }
            void f2()
            {
                DebugHelper.LogMethodName();  //2
            }
        }
     }
