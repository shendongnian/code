    public static class StringExtensions
    {
        public static System.Collections.Generic.IEnumerable<UTF32Char> GetUTF32Chars(this string s)
        {
            var tee = System.Globalization.StringInfo.GetTextElementEnumerator(s);
    
            while (tee.MoveNext())
            {
                yield return new UTF32Char(s, tee.ElementIndex);
            }
        }
    }
    
    public struct UTF32Char
    {
        private string s;
        private int index;
    
        public UTF32Char(string s, int index)
        {
            this.s = s;
            this.index = index;
        }
    
        public int UTF32Code {  get { return char.ConvertToUtf32(s, index); } }
        public double NumericValue { get { return char.GetNumericValue(s, index); } }
        public UnicodeCategory UnicodeCategory { get { return char.GetUnicodeCategory(s, index); } } 
        public bool IsControl { get { return char.IsControl(s, index); } }
        public bool IsDigit { get { return char.IsDigit(s, index); } }
        public bool IsLetter { get { return char.IsLetter(s, index); } }
        public bool IsLetterOrDigit { get { return char.IsLetterOrDigit(s, index); } }
        public bool IsLower { get { return char.IsLower(s, index); } }
        public bool IsNumber { get { return char.IsNumber(s, index); } }
        public bool IsPunctuation { get { return char.IsPunctuation(s, index); } }
        public bool IsSeparator { get { return char.IsSeparator(s, index); } }
        public bool IsSurrogatePair { get { return char.IsSurrogatePair(s, index); } }
        public bool IsSymbol { get { return char.IsSymbol(s, index); } }
        public bool IsUpper { get { return char.IsUpper(s, index); } }
        public bool IsWhiteSpace { get { return char.IsWhiteSpace(s, index); } }
    }
 
