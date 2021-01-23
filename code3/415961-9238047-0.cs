    public interface ILog
    {
        void Trace(string message);
        void Debug(string message);
        void Error(string message);
        // and whatever you need
    }
