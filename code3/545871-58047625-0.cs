    public static class StringExtension
    {
        public static string RemoveDuplicateChars(this string text)
        {
            var output = new StringBuilder();
            var entropy = new HashSet<string>();
            var iterator = StringInfo.GetTextElementEnumerator(text);
    
            while (iterator.MoveNext())
            {
                var character = iterator.GetTextElement();
                if (entropy.Add(character.Normalize()))
                {
                    output.Append(character);
                }
            }
    
            return output.ToString();
        }
    }
