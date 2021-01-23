    var listOne = new List<int>{1,2,3,4,5};
    var listTwo = new List<int>{1,2,3,4,5,7};
    var equal = (listOne.Count == listTwo.Count);
    if (equal)
    {
        listOne.Sort();
        listTwo.Sort();
        equal = listOne.SequenceEqual(listTwo)
    }
    if (equal)
    {
         Console.WriteLine("Equal list");
    }
    else
    {
         Console.WriteLine("Not Equal list");
    }
