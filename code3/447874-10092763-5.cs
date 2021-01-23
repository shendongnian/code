    public class InputReaderFactory
    {
       public IInputReader GetReader(string inputId)
       {
           ...
       }
    }
    public class OutputWriterFactory
    {
       public IOutputWriter GetWriter(string outputId)
       {
          ...
       }
    }
    public class VideoConverterFactory
    {
       public IVideoConverter GetConverter(string inputId, string outputId)
       {
          ...
       } 
    }
    
