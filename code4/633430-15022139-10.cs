    public static List<int> GetDistinctPersonIdsFrom(IEnumerable<Message> messages)
    {
        HashSet<int> ids = new HashSet<int>();
        foreach (var message in messages)
        {
            ids.Add(message.CreatedByPersonID);
            if (message.PostedToPersonID.HasValue)
                ids.Add(message.PostedToPersonID.Value);
        }
        return ids.ToList();
    }
