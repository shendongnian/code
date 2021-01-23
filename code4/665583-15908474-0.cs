    class Debug
    {
        static bool OutputToConsole = true;
    
        public static void LogRequest(string type, string url, StringBuilder params)
        {
            log(type + ":" + new string(' ', 9 - type.Length) + url + " { " + params.ToString() + " }");
        }
    
        public static void LogResponse(string data)
        {
            log("Response: " + data);
        }
    
        private static void log(string msg)
        {
            Trace.WriteLine(msg);
            if(OutputToConsole) Console.WriteLine(msg);
        }
    }
