    using System.Linq;
    List<int> numbers = new List<int> {10, 20, 30, 40};
    List<int> runningTotals = new List<int>(numbers.Count);
    numbers.Aggregate(0, (sum, value) => {
        sum += value; 
        runningTotals.Add(sum); 
        return sum;
    });
