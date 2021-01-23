    public static string ReplaceWithTemplate(this string original, string pattern, string replacement)
    {
      var template = Regex.Match(original, pattern, RegexOptions.IgnoreCase).Value.Remove(0, 1);
      template = template.Remove(template.Length - 1);
      var chars = new List<char>();
      var isLetter = false;
      for (int i = 0; i < replacement.Length; i++)
      {
         if (i < (template.Length)) isLetter = Char.IsUpper(template[i]);
         chars.Add(Convert.ToChar(
                           isLetter ? Char.ToUpper(replacement[i]) 
                                    : Char.ToLower(replacement[i])));
      }
    
      return new string(chars.ToArray());
    }
