    if (p_Criteria.DateFrom != null && p_Criteria.DateFrom > DateTime.MinValue)
    {
        internetQuery = internetQuery.Where(c => c.Timestamp >= p_Criteria.DateFrom);
    }
    if (p_Criteria.DateTo != null && p_Criteria.DateTo > DateTime.MinValue)
    {
        internetQuery = internetQuery.Where(c => c.Timestamp < p_Criteria.DateTo);
    }
