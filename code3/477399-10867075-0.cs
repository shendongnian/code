    var a = Enumerable.Range(1, int.MaxValue/100).ToList();
    var b = Enumerable.Range(50, int.MaxValue/100 - 50).ToList();
    //var c = a.Intersect(b).ToList();
    List<int> c = new List<int>();
    var t1 = DateTime.Now;
    foreach (var item in a)
    {
        if (b.BinarySearch(item) >= 0)
            c.Add(item);
    }
    var t2 = DateTime.Now;
    var tres = t2 - t1;
