    List<object> items = new List<object>();
    items.Add(1);
    items.Add(30);     
    items.Add("4");    
    items.Add("2");    
    
    //since you have string and int value you need to create custom comparer
    items.Sort((x, y) => Convert.ToInt32(x).CompareTo(Convert.ToInt32(y)));
    
    //now clear original cbSize items
    cbSize.Items.Clear();
    
    //and add them back in sorted order
    cbSize.Items.AddRange(items.ToArray());
