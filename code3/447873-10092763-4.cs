    public interface IInputReader
    {
        bool IsSUpported(string inputId);
        void AppendToBuffer(Buffer buffer);
    }
    
    public interface IOutputWriter
    {
        bool IsSUpported(string outputId);
        void WriteFromBuffer(Buffer buffer);
    }
