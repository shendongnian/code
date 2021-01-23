    var items = from o in playerInventory
        group o by o.Type into g
        select new { ItemType = g.Key, Items = g };
    foreach (var g in items)
    {
        string s = string.Format("{0} x {1}", g.ItemType.ToString(), g.Items.Count());
        //now do whatever you want with the string, which will contain, eg, Iron Ore x 3
    }
