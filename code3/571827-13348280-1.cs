    private static void UpdateCommonResultsList(
        List<ManagementInfo> managementInfo,
        KeyValuePair<int, int> item,
        Action<ManagementInfo, int> action)
    {
        foreach (ManagementInfo m in managementInfo
            .Where(m => m.YearMonthNo == item.Key))
        {
            action(m, item.Value);
        }
    }
