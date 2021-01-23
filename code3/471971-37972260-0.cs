    public static class ExceptionExtension
    {
        public static string GetFullTrace(this Exception ex, bool recursive = true)
        {
            string trace = "";
            trace += "Name: " + ex.GetType().Name + "\n";
            trace += "Message: " + ex.Message + "\n";
            trace += "Stack Trace: " + (ex.StackTrace ?? "null") + "\n";
            if (recursive)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    trace += "\n-------------------- Caused by: --------------------\n";
                    trace += "Name: " + ex.GetType().Name + "\n";
                    trace += "Message: " + ex.Message + "\n";
                    trace += "Stack Trace: " + (ex.StackTrace ?? "null") + "\n";
                }
            }
            return trace;
        }
    }
