    var item = MyDictionary.Where(x => x.Key.ToLower() == MyIndex.ToLower()).FirstOrDefault();
        if (item != null)
        {
            TheValue = item.Value;
        }
