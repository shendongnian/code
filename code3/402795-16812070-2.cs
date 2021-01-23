    [TestClass]
      public class UnitTest1
      {
        [TestMethod]
        public void TestMethod1()
        {
          string text = "{\"a\":1}{\"b\":\"hello\"}{\"c\":\"oh}no!\"}{\"d\":\"and\\\"also!\"}";
          var reader = FromStackOverflow.GenerateStreamFromString(text);
          var e = MyJsonExtensions.JsonSplit(reader).GetEnumerator();
          e.MoveNext();
          Assert.AreEqual("{\"a\":1}", e.Current);
          e.MoveNext();
          Assert.AreEqual("{\"b\":\"hello\"}", e.Current);
          e.MoveNext();
          Assert.AreEqual("{\"c\":\"oh}no!\"}", e.Current);
          e.MoveNext();
          Assert.AreEqual("{\"d\":\"and\\\"also!\"}", e.Current);
        }
      }
