    var headers = new List<string> {"14.1.2.3", "14.1", "14.9", "14.2.1", "14.4.2", "14.10.1.2.3.4", "14.7.8.8.2"};
    	headers.Sort(new MySorter());
    class MySorter : IComparer<string>
        {
        public int Compare(string x, string y)
        {
        IList<string> a = x.Split('.');
        IList<string> b = y.Split('.');
        int numToCompare = (a.Count < b.Count) ? a.Count : b.Count;
        for (int i = 0; i < numToCompare; i++)
        {
        if (a[i].Equals(b[i]))
        continue;
        int numa = Convert.ToInt32(a[i]);
        int numb = Convert.ToInt32(b[i]);
         return numa.CompareTo(numb);
        }
        return a.Count.CompareTo(b.Count);
        }
        
        }
