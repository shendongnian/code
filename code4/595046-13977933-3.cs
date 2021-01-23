    void List<Item> SomeOperationFunction(List<Item> target)
    {
      var newList = new List<Item>(target);
      newList.RemoveAt(3);
      return newList; // return copy of list
    }
