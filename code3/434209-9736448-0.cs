    public interface ITextConverter
    {
        bool Convert(string filePath);
    }
    
    
    public static class TextConverterFactory
    {
        public static ITextConverter Create(string extension)
        {
            switch (extension)
            {
               case "txt" : return new TextConverter(); break;
               case "pdf" : return new PdfConverter(); break;
               ...
            }
        }
    }
    
    public class TextConverter : ITextConverter
    {
       bool Convert(string filePath) { ... }
    }
    
    public class PdfConverter : ITextConverter
    {
       bool Convert(string filePath) { ... }
    }
