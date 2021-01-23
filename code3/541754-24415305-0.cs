    using System;
    using System.IO;
    using System.Diagnostics;
    
    public static void Log(string message) {
       StackFrame stackFrame = new System.Diagnostics.StackTrace(1).GetFrame(1);
       string fileName = stackFrame.GetFileName();
       string methodName = stackFrame.GetMethod().ToString();
       int lineNumber = stackFrame.GetFileLineNumber();
    
       Console.WriteLine("{0}({1}:{2})\n{3}", methodName, Path.GetFileName(fileName), lineNumber, message);
    }
