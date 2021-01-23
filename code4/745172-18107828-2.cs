    public Dictionary<int, string> GetItems(int parentId)
    {
        return (from partner in Entities.Instance.Partners
                   order by partner.Text
                  select partner).ToDictionary(x => x.Id, v => v.Name);
    
    }
