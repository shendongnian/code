    public static class Logger {
        public static readonly ILogger Global = new GlobalLogger();
    
    	public static void Log(string message) { Global.Log(message); }
    }
    public class GlobalLogger : ILogger {
        void Log(message) { /* log */ }
    }
