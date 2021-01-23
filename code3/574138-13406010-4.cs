    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetMessage_Input1_ReturnEnterAccountNumberMessage()
        {
            var consoleService = new Mock<IConsoleService>();
            consoleService.Setup(c => c.ReadLine()).Returns("1");
            var bankManager = new BankManager(consoleService.Object);
            bankManager.RunBankApplication();
            consoleService.Verify(c => c.WriteLine("Enter Account Number: "), Times.Once());
        }
        [TestMethod]
        public void GetMessage_Input2_ReturnHelloWorldMessage()
        {
            var consoleService = new Mock<IConsoleService>();
            consoleService.Setup(c => c.ReadLine()).Returns("2");
            var bankManager = new BankManager(consoleService.Object);
            bankManager.RunBankApplication();
            consoleService.Verify(c => c.WriteLine("Hello World!"), Times.Once());
        }
    }
