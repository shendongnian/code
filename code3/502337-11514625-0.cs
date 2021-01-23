    public interface IWriter
    {
        public Write(string text);
    }
    public class Logger
    {
        public static IWriter Writer;
    
        public static void SetWriter(IWriter newWriter)
        {
            Writer = newWriter;
        }
    
        public static void Write(string str)
        {
            Writer.Write(str);
        }
    }
