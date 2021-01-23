    public interface ILoggerFacade
    {
        void Log(string message, Category category, 
                 Priority priority, [CallerMemberName] string callerMethod = "");
    }
