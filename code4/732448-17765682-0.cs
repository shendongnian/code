    using System;
    using System.Linq;
    
    public static class CharExtentions
    {
        public static bool IsVowel(this char character)
        {
            return new[] {'a', 'e', 'i', 'o', 'u'}.Contains(char.ToLower(character));
        }
    }
