         var list = new List<int>{1,2,4,5,6};
        var even = list.Where(m => m%2 == 0).Tolist();
        list.Add(8);
        foreach (var i in even)
        {
            Console.WriteLine(i);
        }
    //new*
        list.Add(10);
        foreach (var i in even)
        {
            Console.WriteLine(i);
        }
