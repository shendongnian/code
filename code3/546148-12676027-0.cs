    // Load IDs into a hashset so Contains is O(1) not O(n)
    var hashSetOfIDs = new HashSet<int>(listOfIDs);
    // Aggreagate count and both sums in one pass, then calculate average.
    var result = results.Where(cc => hashSetOfIDs.Contains(cc.ID)).Aggregate(
        new { Count = 0, Sum = 0, AverageSum = 0f },
        (a, cc) => new {
            Count = a.Count + 1,
            Sum = a.Sum + cc.numberToSum,
            AverageSum = a.AverageSum + cc.numToAverage },
        a => new { 
            Sum = a.Sum,
            Average = a.Count > 0 ? a.AverageSum / a.Count : float.NaN });
    // Extract results
    var sum = result.Sum;
    var average = result.Average;
