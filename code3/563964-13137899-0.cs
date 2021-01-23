    public class SilverCountLineComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string xPart = x.Split(new char[] {'_'}, StringSplitOptions.RemoveEmptyEntries)[3];
            string yPart = y.Split(new char[] {'_'}, StringSplitOptions.RemoveEmptyEntries)[3];
            int xNum = Int32.Parse(xPart);
            int yNum = Int32.Parse(yPart);
            return xNum.CompareTo(yNum);
        }
    }
