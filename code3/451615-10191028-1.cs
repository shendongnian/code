    if (p_Criteria.Titles.Count > 0)
    {
         internetQuery = internetQuery.AsEnumerable().Where(c => p_Criteria.Titles.Contains(c.Title)).AsQueryable();
    }
    if (p_Criteria.MachineNames.Count > 0)
    {
          internetQuery = internetQuery.AsEnumerable().Where(c => p_Criteria.MachineNames.Contains(c.MachineName)).AsQueryable();
    }
    if (p_Criteria.Severities.Count > 0)
    {
          internetQuery = internetQuery.AsEnumerable().Where(c => p_Criteria.Severities.Contains(c.Severity)).AsQueryable();
    }
