    private List<List<Work>> GetCombinations(double currentSum,
                                             List<Work> currentWorks,
                                             List<Work> remainingWorks,
                                             double minSum,
                                             double maxSum)
    {
        // Filter out the works that would go over the maxSum.
        var newRemainingWorks = remainingWorks.Where(x => currentSum + x.Time <= maxSum)
                                              .ToList();
        // Create the possible combinations by adding each newRemainingWork to the 
        // list of current works.
        var sums = newRemainingWorks
                       .Select(x => new
                              {
                                  Works = currentWorks.Concat(new [] { x }).ToList(),
                                  Sum = currentSum + x.Time
                              })                                
                       .ToList();
        // The initial combinations are the possible combinations that are
        // within the sum range.				   
        var combinations = sums.Where(x => x.Sum >= minSum).Select(x => x.Works);
        // The additional combinations get determined in the recursive call.
        var newCombinations = from index in Enumerable.Range(0, sums.Count)
                              from combo in GetCombinations
                                            (
                                                sums[index].Sum,
                                                sums[index].Works,
                                                newRemainingWorks.Skip(index + 1).ToList(),
                                                minSum,
                                                maxSum
                                            )
                              select combo;
        return combinations.Concat(newCombinations).ToList();        
    }
