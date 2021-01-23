    public class LineHandler
    {
        // Start indices and lengths for string and two numbers
        int si, sl, n1i, n1l, n2i, n2l;
        Dictionary<string, int> sums;
        public LineHandler(int si, int sl, int n1i, int n1l, int n2i, int n2l)
        {
            this.si = si; this.sl = sl; this.n1i = n1i;
            this.n1l = n1l; this.n2i = n2i; this.n2l = n2l;
            sums = new Dictionary<string,int>();
        }
        
        public void HandleString(string s)
        {
            string key = s.Substring(si, sl);
            int sum = int.Parse(s.Substring(n1i, n1l)) + int.Parse(s.Substring(n2i, n2l));
            if (sums.ContainsKey(key))
                sums[key] += sum;
            else
                sums[key] = sum;
        }
        public Dictionary<string, int> Sums { get { return sums; } }
    }
