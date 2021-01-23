    class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int ix = x == "b" ? 0 : x == "c" ? 1 : 2;
            int iy = y == "b" ? 0 : y == "c" ? 1 : 2;
            return ix.CompareTo(iy);
        }
    }
    var example = new List<string> { "c", "b", "a", "d", "c", "foo", "e", "", "b", "1", "d"};
    example.Sort(new MyComparer());
    foreach (var s in example)
        Console.WriteLine(s);
