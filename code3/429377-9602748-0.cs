    public static string[][] FetchMergedColumns(params int[] columnNumbers)
    {
        var dataSample = new[]
        {
            new[] { "Fish", "Dog", "Cat" },
            new[] { "Blue", "Red", "Black" },
            new[] { "Cloudy", "Rain", "Thunder" },
            new[] { "10", "33", "55" }
        };
        return columnNumbers
            .Select(colNum => dataSample.ElementAt(colNum - 1))
            .ToArray();
    }
