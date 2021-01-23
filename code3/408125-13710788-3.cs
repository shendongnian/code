    [DataTestMethod]
    [DataRow(12,3,4)]
    [DataRow(12,2,6)]
    [DataRow(12,4,3)]
    public void DivideTest(int n, int d, int q)
    {
      Assert.AreEqual( q, n / d );
    }
