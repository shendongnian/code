    static void MyMeth(List<int> numbers)
    {
      var query = numbers.AsEnumerable().Reverse();  // fine too; Linq
      // ... use query ...
    }
