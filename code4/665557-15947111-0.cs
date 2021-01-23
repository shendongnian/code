    public string st = "101"; // hardcoded for now
    public char[] cs;
    public List<string> variations;
    static void Main()
    {
        cs = st.ToCharArray();
        variations = new List<string>();
        vary("",0);
    }
    static void vary(string m, int n)
    {     
        for (int i = n; i < cs.Count(); i++)
        {
            if (cs[i] == '0' || cs[i] == '1')
            {
                // recurse
                combo(m + (cs[i] == '0' ? "0" : "1"), i + 1);
                combo(m + (cs[i] == '0' ? "Y" : "Z"), i + 1);
            }
            m += cs[i];
        }
        if(!variations.Contains(m))
            variations.Add(m);
    }
