    public class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            //todo null checks on input
            var pairs = x.Zip(y, (a, b) => new { x = a, y = b });
            foreach (var pair in pairs)
            {
                int value = pair.x.CompareTo(pair.y);
                if (value != 0)
                    return value;
            }
            //if we got here then either they are the same,
            //or one starts with the other
            return y.Length.CompareTo(x.Length); //note x and y are reversed here
        }
    }
