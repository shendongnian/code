        var listOne = new List<int>{1,2,3,4,5};
        var listTwo = new List<int>{1,2,3,4,5,7};
        listOne.Sort();
        listTwo.Sort();
        if (listOne.SequenceEqual(listTwo))
                {
                    Console.WriteLine("Equal list");
                }
                else
                {
                    Console.WriteLine("Not Equal list");
                }
