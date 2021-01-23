    using(IEnumerator<Item> iterator = Items.GetEnumerator())
    while(iterator.MoveNext())
    {
      Item item = iterator.Current;
      //do stuff
    }
