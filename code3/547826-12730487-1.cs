    private List<List<Work>> GetCombinations(int currentSum,
                                             List<Work> currentWork,
                                             List<Work> remainingWork,
                                             double minSum,
                                             double maxSum)
    {
        List<List<Work>> combinations = new List<List<Work>>();
        var newRemainingWork = remainingWork.Where(x => currentSum + x.Time <= maxSum)
                                            .ToList();
        var sums = newRemainingWork
                       .Select(x => new
                              {
                                  Work = currentWork.Concat(new [] { x }).ToList(),
                                  Sum = currentSum + x.Time
                              })                                
                       .ToList();
        combinations = sums.Where(x => x.Sum >= minSum).Select(x => x.Work).ToList();
        var newCombinations = from index in Enumerable.Range(0, sums.Count)
                              from combo in GetCombinations
                                            (
                                                item[index].Sum,
                                                item[index].Work,
                                                newRemainingWork.Skip(index + 1).ToList(),
                                                minSum,
                                                maxSum
                                            )
                              select combo;
        return combinations.Concat(newCombinations).ToList();        
    }
