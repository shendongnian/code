    static void Main(string[] args)
    {
        List<int> arr1 = new List<int>();
        List<int> arr2 = new List<int>();
        List<int> prod = new List<int>();
        arr1.AddRange(new int[] { 1, 0, 1 });
        arr2.AddRange(new int[] { 1, 1, 0 });
        prod = arr1.Select((item, index) => new { item, index })
            .Join(arr2.Select((item, index) => new { item, index }), i => i.index, i => i.index, (a, b) => a.item * b.item)
            //Where makes it variable
            .Where(i => i > 0)
            .ToList();
    }
