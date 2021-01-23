    class Item
    {
        public string ItemNo { get; set; }
        public string FileName { get; set; }
    }
    var result = list.GroupBy(item => item.ItemNo)
                     .Select(g => new Item
                       {
                           ItemNo = g.Key,
                           FileName = string.Join(", ",  g.Select(s => s.FileName))
                       });
