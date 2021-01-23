        var listOne = new List<int>{1,2,3,4,5};
        var listTwo = new List<int>{1,2,3,4,5,7};
         if (listOne.OrderBy(m => m).SequenceEqual(listTwo.OrderBy(m => m)))
            {
                Console.WriteLine("Equal list");
            }
            else
            {
                Console.WriteLine("Not Equal list");
            }
