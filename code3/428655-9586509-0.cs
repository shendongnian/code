    class MyComparer : IComparer
    {
        string key;
        public MyComparer(string key)
        {
            this.key = key;
        }
        public int Compare(object x, object y)
        {
            return ((int)((Hashtable)x)[key]).CompareTo((int)((Hashtable)y)[key]);
        }
    }
