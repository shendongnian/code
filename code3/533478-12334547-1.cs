    public static class MyEnumerableExtensions {
    
        public static IEnumerable<double> CumulativeSum(this IEnumerable<double> @this) {
            var sum = 0;
            foreach (var value in @this) { sum += value; yield return sum; }
        }
    
    }
    
    // then to compute the sum you want
    var rollingSum = ViewData.Select(m => m.YData).CumulativeSum();
    var rollingSumWithDates = ViewData.Zip(rollingSum, (m, sum) => new DepartmentOverviewDetailsViewModel.GraphJSONViewModel { XData = m.XData, YData = sum })
        .ToArray();
