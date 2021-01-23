    static void MyMeth(List<int> numbers)
    {
      var query = ((IEnumerable<int>)numbers).Reverse();  // fine; Linq
      // ... use query ...
    }
