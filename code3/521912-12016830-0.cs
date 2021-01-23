      class Item
        {
            public string ItemNo { get; set; }
            public string FileName { get; set; }
        }
      var result = list.GroupBy(item => item.ItemNo)
                .ToDictionary(group => group.Key,
                              group => group.Select(s => s.FileName))
                .Select(p => new Item { ItemNo = p.Key, 
                               FileName = string.Join(", ", p.Value)});
