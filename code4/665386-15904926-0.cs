    var d = new Dictionary<string, object>();
    var s = new List<object>();
    for (int i =0 ; i != 10000000 ; i++) {
        d.Add(""+i, i);
        s.Add(i);
    }
    var sw = new Stopwatch();
    sw.Start();
    foreach(object o in d.Values) {
        if (o == null) throw new ApplicationException();
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
    sw.Reset();
    sw.Start();
    foreach (object o in s) {
        if (o == null) throw new ApplicationException();
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
