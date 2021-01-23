    var listDegree = new[] { 1, 4, 5, 6 };
    int lowerIndex = 2;
    var combinations = new Facet.Combinatorics.Combinations<int>(
        listDegree,
        lowerIndex,
        Facet.Combinatorics.GenerateOption.WithoutRepetition
    );
     // get total costs overall
     int totalCosts = combinations.Sum(c => c.Sum());
     // get a List<List<int>> of all combination (the inner list count is 2=lowerIndex since you want pairs)
     List<List<int>> allLists = combinations.Select(c => c.ToList()).ToList();
     // output the result for demo purposes
     foreach (IList<int> combis in combinations)
     {
         Console.WriteLine(String.Join(" ", combis));
     }
