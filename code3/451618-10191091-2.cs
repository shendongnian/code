        if (p_Criteria.Titles.Any())
        {
            internetQuery = internetQuery
                .Where(c => p_Criteria.Titles.Contains(c.Title));
        }
        if (p_Criteria.MachineNamesAny())
        {
            internetQuery = internetQuery
                .Where(c => p_Criteria.MachineNames.Contains(c.MachineName));
        }
        if (p_Criteria.Severities.Any())
        {
            internetQuery = internetQuery
                .Where(c => p_Criteria.Severities.Contains(c.Severity));
        }
