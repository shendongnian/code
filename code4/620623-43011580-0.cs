    static string Locker="foo";
    [Test, Order(1)]
    public void Test1()
    {
      lock(Locker)
      {
        //....
      }
    }
    [Test, Order(2)]
    public void Test2()
    {
      lock(Locker)
      {
        //....
      }
    }
