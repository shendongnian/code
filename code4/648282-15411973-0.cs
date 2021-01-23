    interface IViewValue
    {
        int ViewValue { get; set; }
    }
    public class SomeViewModel : IViewValue
    {
        public int ViewValue { get; set; }
    }
    private int SumValues<T, TRes>(IEnumerable<T> data, Func<T, TRes> transformation)
                                                where TRes : IViewValue
    {
        var transformedData = data.Select(transformation);
        IEnumerable<int> listOfValues = transformedData.Select(i => i.ViewValue);
        var sum = listOfValues.Sum();
        return sum;
    }
