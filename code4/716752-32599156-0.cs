    var lowerlimit = DateTime.Today.AddDays(-52).ToString("yyyy-MM-dd");
    
    string dateRangeFilter = TableQuery.CombineFilters(
        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "1005"),
        TableOperators.And,
        TableQuery.GenerateFilterConditionForDate("TimeStamp", QueryComparisons.GreaterThanOrEqual, lowerlimit));
