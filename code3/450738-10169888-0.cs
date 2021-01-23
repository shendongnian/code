    myColl
         .GroupBy(item => new { item.Id, item.ItemType, item.ChannelName })
         .OrderByDescending(item => item.CreationDate)
         .ToList() 
         .Select(res =>
                new ChannelRowUi(res.ToList())
                {
                    ChannelName = res.Key.ChannelName,
                    ItemType = res.Key.ItemType.ToString()
                })
        
