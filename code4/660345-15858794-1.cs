    List<string> stringList = new List<string>();
    stringList.Add("One");
    stringList.Add("Two");
    IEnumerable<string> stringEnumerable = stringList.AsEnumerable();
    List<string> stringList2 = stringEnumerable as List<string>;
    if (stringList2 != null)
        stringList2.Add("Three");
    foreach (var s in stringList)
        Console.WriteLine(s);
