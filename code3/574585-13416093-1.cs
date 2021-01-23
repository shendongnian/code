    int Min3(int x, int y, int z) 
    {
          if(x<=y)
          {
            if(x<=z)
            { //x<=z && x<=y
              return x;
            }
            //z<x && x<=y 
            return z;
          }
          //y<x
          if(z<=y) return z;
          //y<z && y<x
          return y;
    }
    [TestMethod]
    public void Test_Zip3()
    {
      int[] a = { 2, 3, 5 };
      int[] b = { 3, 2, 5 };
      int[] c = { 5, 1, 5 };
      IEnumerable<int> result = a.Zip3(b, c, Min3);
      CollectionAssert.AreEqual(new[] {2, 1, 5}, result.ToArray());
    }
    [TestMethod]
    public void Zip_With_Different_ArrayLength()
    {
      int[] a = { 2, 3, };
      int[] b = { 3, 2, 5 };
      int[] c = { 5, 1, 5, 8 };
      var result = a.Zip3(b, c, Min3);
      CollectionAssert.AreEqual(new[] {2, 1}, result.ToArray());
    }
    [TestMethod]
    public void Zip_With_EmptyArray()
    {
      int[] a = { 2, 3, };
      int[] b = { 3, 2, 5 };
      int[] c = { };
      var result = a.Zip3(b, c, Min3);
      CollectionAssert.AreEqual(new int[0], result.ToArray());
    }
    [TestMethod]
    public void Zip_With_First_ArrayEmpty()
    {
      int[] a = { };
      int[] b = { 3, 2, 5 };
      int[] c = { 1, 8, };
      var result = a.Zip3(b, c, Min3);
      CollectionAssert.AreEqual(new int[0], result.ToArray());
    }
    [TestMethod]
    public void Zip_With_All_Arrays_Empty()
    {
      int[] a = { };
      int[] b = { };
      int[] c = { };
      var result = a.Zip3(b, c, Min3);
      CollectionAssert.AreEqual(new int[0], result.ToArray());
    }
