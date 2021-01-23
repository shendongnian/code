    public static IEnumerable<char> RemoveDiacriticsEnum(string src, bool compatNorm, Func<char, char> customFolding)
    {
        foreach(char c in src.Normalize(compatNorm ? NormalizationForm.FormKD : NormalizationForm.FormD))
        switch(CharUnicodeInfo.GetUnicodeCategory(c))
        {
          case UnicodeCategory.NonSpacingMark:
          case UnicodeCategory.SpacingCombiningMark:
          case UnicodeCategory.EnclosingMark:
            //do nothing
            break;
          default:
            yield return customFolding(c);
            break;
        }
    }
    public static IEnumerable<char> RemoveDiacriticsEnum(string src, bool compatNorm)
    {
      return RemoveDiacritics(src, compatNorm, c => c);
    }
    public static string RemoveDiacritics(string src, bool compatNorm, Func<char, char> customFolding)
    {
      StringBuilder sb = new StringBuilder();
      foreach(char c in RemoveDiacriticsEnum(src, compatNorm, customFolding))
        sb.Append(c);
      return sb.ToString();
    }
    public static string RemoveDiacritics(string src, bool compatNorm)
    {
      return RemoveDiacritics(src, compatNorm, c => c);
    }
    
