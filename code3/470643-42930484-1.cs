    [TestClass]
    public class ProjectTestBase : FrameworkTestBase
    { 
      public CommonActions common { get; set; } = new CommonActions();
      [TestInitialize]
       public void TestInitialize() => common.TestInitialize(false);
