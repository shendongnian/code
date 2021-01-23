    public Payload ConvertJson(string json)
    {
        var payload = new Payload();
    
        var container = JToken.Parse(json) as JContainer;
        if(container == null) return payload;
    
        payload.Items = new List<Item>(container.Count);
    
        foreach (var child in container)
        {
            var childJson = child.FirstOrDefault();
            if (childJson == null) continue;
            var item = childJson.ToObject<Item>();
            if (item.item_id == 0)
            {
                item.item_id = Convert.ToInt32(((JProperty)child).Name);
            }
            payload.Items.Add(item);
        }
        return payload;
    }
