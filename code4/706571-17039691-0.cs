    [TestClass]
    public class UnitTest1
    {
      int counter = 0;
      [TestMethod]
      public void TestMethod1()
      {
        BindingList<Test1> list = new BindingList<Test1>();
        list.RaiseListChangedEvents = true;
        int evtCount = 0;
        list.ListChanged += (object sender, ListChangedEventArgs e) =>
        {
          Console.WriteLine("Changed, type: {0}", e.ListChangedType);
          ++evtCount;
        };
        list.Add(new Test1() { Data = "yo yo" });
        Assert.AreEqual(1, evtCount);
        list[0].Data = "ya ya";
        Assert.AreEqual(2, evtCount);
      }
    }
