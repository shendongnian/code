    class LookupItem
    {
        public int a;
        public int b;
        public float c;
        public float d;
    }
    class LookupItemTable : List<LookupItem>
    {
        public void Add(int a, int b, float c, float d)
        {
            LookupItem item = new LookupItem();
            item.a = a;
            item.b = b;
            item.c = c;
            item.d = d;
            Add(item);
        }
    }
    private static LookupItemTable _lookupTable = new LookupItemTable {
        { 1, 2, 3, 4 },
        { 5, 6, 7, 8 }
    };
