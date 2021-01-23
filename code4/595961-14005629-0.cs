        static void traceFunc(string msg)
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(true);
            string file = trace.GetFrame(1).GetFileName();
            int line = trace.GetFrame(1).GetFileLineNumber();
            System.Diagnostics.Trace.WriteLine(file + "(" + line.ToString() + ") " + msg);
        }
