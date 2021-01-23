    List<int> yourlist = new List<int>(){1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
    IEnumerable<int> newlist = yourlist.Skip(2).Take(3);
                        
    foreach(var i in newlist)
    {
       Console.WriteLine(i);
    }
