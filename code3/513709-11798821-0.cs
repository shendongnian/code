    public class Language
    {
      string Code{get;set;}
      string EnglishName{get;set;}
      string NativeName{get;set;}
    }
    public class Document
    {
      public int ID{get; private set;}//no public set as it corresponds to an automatically-set column
      public string LanguageCode{get;set;}
      public string Title{get;set;}
      public string Text{get;set;}
    }
