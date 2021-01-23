    if (!string.IsNullOrEmpty(p_Criteria.FreeText))
    {
        internetQuery = internetQuery
            .Where(c => c.FormattedMessage.StartsWith(p_Criteria.FreeText));
    }
