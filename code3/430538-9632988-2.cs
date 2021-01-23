    [TestFixture]
    public class ControllerTest
    {
        private Controller controller;
        private Mock<IFileSaver> fileSaver;
        private Mock<IView> view;
        private Action ButtonClickAction;
        [SetUp]
        public void SetUp()
        {
            view = new Mock<IView>();
            view.Setup((v) => v.AddButtonClickHandler(It.IsAny<Action>()))
                .Callback<Action>((a) => ButtonClickAction = a);
            fileSaver = new Mock<IFileSaver>();
            controller = new Controller(view.Object, fileSaver.Object);
            view.VerifyAll();
        }
        [Test]
        public void No_button_click_nothing_happens()
        {
            fileSaver.Setup(f => f.SaveFileWithRandomLine()).Returns(true);
            view.VerifySet(v => v.Result = It.IsAny<String>(), Times.Never());
        }
        [Test]
        public void Say_it_worked()
        {
            fileSaver.Setup(f => f.SaveFileWithRandomLine()).Returns(true);
            ButtonClickAction();
            view.VerifySet(v => v.Result = "It worked!");
        }
        [Test]
        public void Say_it_failed()
        {
            fileSaver.Setup(f => f.SaveFileWithRandomLine()).Returns(false);
            ButtonClickAction();
            view.VerifySet(v => v.Result = "It failed!");
        }
    }
