    for (int i = 1; i <= a.PageCount; i++)
    {
        String contain = a.Pages[i].Text
        if (contain != "")
        {
            // Inside is dictionary of keys and value contain page where I found it
            foreach (KeyValuePair<string, List<int>> pair in inside)
            {
                if (contain.Contains(pair.Key))
                    pair.Value.Add(i);
            }
        }
    }
