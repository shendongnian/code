    [TestClass]
    public class UnitTest
    {
        private IUnityContainer container;
        [TestInitialize]
        public void TestInitialize()
        {
            container = new UnityContainer();
            container.RegisterType<IShape, Circle>();
        }
        [TestMethod]
        public void Test1()
        {
           var drawing = container.Resolve<Drawing>();
           
           // Or Buildup works too:
           //
           // var drawing = new Drawing();
           // container.BuildUp(drawing)
           this.drawing.Draw();
        }    
    }
