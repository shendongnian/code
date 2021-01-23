    private static void UpdateCommonResultsList(
        List<ManagementInfo> managementInfo,
        KeyValuePair<int, int> item,
        Action<ManagementInfo, int> action)
    {
        managementInfo
            .Where(m => m.YearMonthNo == item.Key)
            .Select(m => action(m, item.Value))
            .ToList();
    }
