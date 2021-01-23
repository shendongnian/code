    public class CapitalizerComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int[] xCount = new int[26];
            int[] yCount = new int[26];
            foreach(char c in x)
            {
                if (char.IsUpper(c))
                    xCount[c-'A']++;
            }
            foreach (char c in y)
            {
                if (char.IsUpper(c))
                    yCount[c-'A']++;
            }
            for (int i = 0; i < xCount.Length; i++)
            {
                if(xCount[i] > yCount[i])
                    return -1;
                else if(yCount[i] > xCount[i])
                    return 1;
            }
            return x.CompareTo(y);
        }
    }
