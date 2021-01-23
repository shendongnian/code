    [TestClass]
    public class TicketControllerTests : ControllerTestBase
    {
        protected Mock<ITicketRepository> MockTicketRepository;
        [TestMethod]
        public void IndexActionModelIsTypeOfTicketModel()
        {
            //ARRANGE
            MockTicketRepository = new Mock<ITicketRepository>(MockBehavior.Strict);
            MockTicketRepository.Setup(x => x.GetById(Constants.TICKET_ID)).Returns(Constants.CLIENT_TICKET);
            var controller = new TicketController(MockTicketRepository.Object);
            //ACT - try to keep ACT as lean as possible, ideally just the method call you're testing
            var result = controller.Index(Constants.TICKET_ID);
            //ASSERT
            var model = ((ViewResult)result).ViewData.Model;
            Assert.That(model, Is.InstanceOfType<TicketModel>(), "ViewModel should have been an instance of TicketModel.")
        }
    }
