    static private String MaskInput(String input, int shownCharacters)
    {
      if (input.Length < shownCharacters)
      {
        shownCharacters = input.Length;
      }
      String endCharacters = input.Substring(input.Length - shownCharacters);
      return String.Format("{0}{1}", "".PadLeft(input.Length - shownCharacters, '*'), endCharacters);
    }
