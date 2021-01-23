    public struct Converter {
      public string         Extension;
      public Action<string> ConvertAction;
    }
    public static class Extensions {
      static Action<string> WordToPdf  = (s) => {;};
      static Action<string> ExcelToPdf = (s) => {;};
      static Action<string> ImgToPdf   = (s) => {;};
      public static IEnumerable<Converter> Converters = new List<Converter> {
        new Converter {Extension = ".doc",  ConvertAction = WordToPdf},
        new Converter {Extension = ".docx", ConvertAction = WordToPdf},
        new Converter {Extension = ".txt",  ConvertAction = WordToPdf},
        new Converter {Extension = ".rtf",  ConvertAction = WordToPdf},
        new Converter {Extension = ".xls",  ConvertAction = ExcelToPdf},
        new Converter {Extension = ".xlsx", ConvertAction = ExcelToPdf},
        new Converter {Extension = ".jpg",  ConvertAction = ImgToPdf},
        new Converter {Extension = ".png",  ConvertAction = ImgToPdf},
        new Converter {Extension = ".jpeg", ConvertAction = ImgToPdf},
        new Converter {Extension = ".doc",  ConvertAction = ImgToPdf}
      };
      public void RunIt(string extension, string convertFilePath) {
        extension = extension.ToLower();
        var action = ( from a in Converters 
                       where a.Extension.Equals(extension) 
                       select a.ConvertAction).First();
        if (action != null) action(convertFilePath);
      }
    }
