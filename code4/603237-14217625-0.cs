    public class Foo : IFormattable
    {
        public string Text { get; set; }
        public IList<Foo> InnerList { get; set; } 
    
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "0";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;
    
            int indent = 0;
            Int32.TryParse(format, out indent);
            string indentString = "";
            while(indent > indentString.Length)
            {
                indentString += " ";
            }
            var toString = String.Format("{0}{1}", indentString, Text);
            foreach (Foo foo in InnerList ?? new List<Foo>())
            {
                toString += String.Format("\n{0}", foo.ToString((indent + 1).ToString(), formatProvider));
            }
            return toString;
        }
    
        public override string ToString()
        {
            return ToString("0", CultureInfo.CurrentCulture);
        }
    }
