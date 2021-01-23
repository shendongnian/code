    IParseColorString
    {
      ColorParts Parse(String s);
    }
    ColorParts
    {
      public string R {get;}
      public string G {get;}
      public String B {get;}
      // or if you wanted the int directly have int return type instead of string
    }
