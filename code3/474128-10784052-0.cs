    [Testclass]
    public class TestStacks
    {
      private Stack<string> emptyStack;
      private Stack<string> singleItemStack;
    
      [TestInitialize]
      public void Setup()
      {
        singleItemStack = new Stack<string>();
        singleItemStack.Push("Item");
        emptyStack = new Stack<string>();
      }
      [TestMethod]
      public void TestPush()
      {       
        emptyStack.Push("Added");
        Assert.AreEqual(1, emptyStack.Count);
      }
      [TestMethod]
      public void TestRemove()
      {       
        singleItemStack.Pop();
        Assert.AreEqual(0, singleItemStack.Count);
      }  
    
      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void TestPopFromEmpty()
      {       
        emptyStack.Pop();
      }  
    }
