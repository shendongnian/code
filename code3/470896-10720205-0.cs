    // The result list
    IEnumerable<IList<KeyValuePair<char, int>>> result;
    
    // If there are no requestedKeys there is no result expected
    if(requestedKeys.Count() > 0)
    {
        // Loop through all request keys to cross join them together
        foreach (var key in requestedKeys)
        {
            if (result == null)
            {
                // First time the innerlist List<KeyValuePair<char, int>> will contain 1 item
                // Don't forget to use ToList() otherwise the expression will be executed to late.
                result = objects.Where(m => m.Key == key).Select(m => new List<KeyValuePair<char, int>>() { m }).ToList();
            }
            else
            {
                // Except for the first time the next subresult will be cross joined
                var subresult = objects.Where(m => m.Key == key).Select(m => new List<KeyValuePair<char, int>>() { m });
                result = result.Join(
                    subresult,
                    l1 => 0, // This and the next parameter does the cross join trick
                    l2 => 0, // This and the previous parameter does the cross join trick
                    (l1, l2) => l1.Concat(l2).ToList() // Concat both lists which causes previous list plus one new added item
                    ).ToList(); // Again don't forget to 'materialize' (I don't know it is called materialization in LINQ-to-Objects 
                                // but it has simular behaviors because the expression needs to be executed right away)
            }
        }           
    }
    return result;
