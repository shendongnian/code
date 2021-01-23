    public enum ResultType
    {
      Ok,
      NotOk,
    }
    public abstract class DBRepository
    {
      public abstract ResultType GetResult();
    }
    public class ClassToTest
    {
      public DBRepository Rep { get; set; }
      public virtual bool MethodA()
      {
        //Some logic
        var result = MethodB();
        //Do some logic against result;
        return result == ResultType.Ok;
      }
      protected virtual ResultType MethodB()
      {
        return Rep.GetResult();
      }
    }
    public class DBRepositoryMock : DBRepository
    {
      public ResultType FakeReturn { get; set; }
      public override ResultType GetResult()
      {
        return FakeReturn;
      }
    }
    public class ClassToTest_MethodA : ClassToTest
    {
      public ResultType MethodB_FakeReturn { get; set; }
      protected override ResultType MethodB()
      {
        return MethodB_FakeReturn;
      }
    }
    // tests
    [TestMethod]
    public void Test1()
    {
      ClassToTest mock = new ClassToTest_MethodA();
      (mock as ClassToTest_MethodA).MethodB_FakeReturn = ResultType.Ok;
      Assert.IsTrue(mock.MethodA());
    }
    // or using injection
    [TestMethod]
    public static void Test2()
    {
      var obj = new ClassToTest();
      obj.Rep = new DBRepositoryMock { FakeReturn = ResultType.NotOk };
      Assert.IsFalse(obj.MethodA());
    }
