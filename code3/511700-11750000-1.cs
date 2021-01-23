    public static class ExtensionMethod
    {
        public static string Strip(this string str, char[] otherCharactersToRemove)
        {
            List<char> charactersToRemove = (from s in str
                                  where char.IsWhiteSpace(s)
                                  select s).ToList();
            charactersToRemove.AddRange(otherCharactersToRemove);
            string str2 = str.Trim(charactersToRemove.ToArray());
            return str2;
        }
    }
