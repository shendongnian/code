    HashSet<int> h = new HashSet<int>();
    h.Add(0);
    h.Add(1);
    int[] ints = new[] { 0, 1, 1, 0 };
    h.SetEquals(ints); // true, ignores duplicates because it's a set
    h.Equals(ints); // false, correct because not even the same types
