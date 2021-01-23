        [Test]
        public void teststuff()
        {
            Mock<MyTestObj> myTestObj_mock = new Mock<MyTestObj>();
            myTestObj_mock.Setup(e => e.do_work(It.IsAny<AnObject>()));
            AnObject tester = new AnObject();
            tester.anAction(myTestObj_mock.Object);
        }
...
    public class MyTestObj
    {
        public virtual void do_work(AnObject o)
        {
        }
    }
    public class AnObject
    {
        public void anAction(MyTestObj obj)
        {
            obj.do_work(new AnObject());
        }
    }
