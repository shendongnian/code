    List<string> list1 = new List<string>(){ "A", "C", "F", "H", "I" };
    List<string> list2 = new List<string>(){ "B", "D", "F", "G", "L" };
    var intersect = list1.Intersect(list2);
    foreach (var i in intersect)
    {
         Console.WriteLine(i);
    }
