    public class TestObject
    {
      public string A { get; set; }
      public int Index { get; set; }
    }
    public void Example()
    {
      List<TestObject> testObjects = new List<TestObject>();
      testObjects.Add(new TestObject() { A = "B" });
      testObjects.Add(new TestObject() { A = "C" });
      testObjects.Add(new TestObject() { A = "A" });
      var objects = testObjects.OrderBy(x => x.A).Select((x, i) => new TestObject() { A = x.A, Index = i });
    }
