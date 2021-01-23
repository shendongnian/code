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
            view.VerifyAll(); //This basically tests if a handler was added via AddButtonClickHandler
        }
        [Test]
        public void No_button_click_nothing_happens()
        {
            fileSaver.Setup(f => f.SaveFileWithRandomLine()).Returns(true);
            view.Verify(v => v.DisplayMessage(It.IsAny<String>()), Times.Never());
        }
        [Test]
        public void Say_it_worked()
        {
            fileSaver.Setup(f => f.SaveFileWithRandomLine()).Returns(true);
            ButtonClickAction();
            view.Verify(v => v.DisplayMessage("It worked!"));
        }
        [Test]
        public void Say_it_failed()
        {
            fileSaver.Setup(f => f.SaveFileWithRandomLine()).Returns(false);
            ButtonClickAction();
            view.Verify(v => v.DisplayMessage("It failed!"));
        }
    }
