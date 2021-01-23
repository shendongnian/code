    static void MyMeth(int[] numbers)
    {
      var query = numbers.Reverse();  // works fine, calls Linq extension
      // ... use query ...
    }
