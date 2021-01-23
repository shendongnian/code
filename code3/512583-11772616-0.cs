    public virtual IEnumerable<HistoryContainer> ReadFirst()
    {
        using (HistoryContainer x = new HistoryContainer())
        {
            foreach (var item in x.HistoryData.where(b => b.MP == IpAddress))
            {
                _history.Add(new HistoryItem(item));
            } 
        }
    }
