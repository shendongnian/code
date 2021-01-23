    IList newlist = new List<Item>();
    foreach(item anItem in myList)
    {
         newList.Add(item.ReturnCopy());
    }
