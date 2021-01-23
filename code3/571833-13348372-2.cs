    public static void UpdateResults(this List<ManagementInfo> managementInfo,
    Func<bool> updateCondition, Action<ManagementInfo> updateAction)
        {
            managementInfo
                .Where(m => updateCondition(m))
                .Select(m => updateAction(m))
                .ToList();
        }
