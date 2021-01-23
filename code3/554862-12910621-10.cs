    using System;
    using System.Diagnostics;
    namespace A3
    {
        public class Program
        {
            static void Main(string[] args)
            {
                StackFrame[] stackFrames = GetStackFrames();
                foreach (StackFrame stackFrame in stackFrames)
                    Console.WriteLine(stackFrame.GetMethod().Name); // write method name
                
                Console.ReadLine();
            }
            //[MethodImpl(MethodImplOptions.NoInlining)]
            static StackFrame[] GetStackFrames()
            {
                StackTrace stackTrace = new StackTrace(); // get call stack
                return stackTrace.GetFrames(); // get method calls (frames)
            }
        }
    }
