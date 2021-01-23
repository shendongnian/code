    string original = "peter piper picked a pack of pickled peppers, the peppers were sweet and sower for peter, peter thought";
    var words = original.Split(new[] {' ',','}, StringSplitOptions.RemoveEmptyEntries);
    var groups = words.GroupBy(w => w);
    foreach(var item in groups)
        Console.WriteLine("Word {0}: {1}", item.Key, item.Count());
 
