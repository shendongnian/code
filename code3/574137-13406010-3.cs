    public class BankManager
    {
        private IConsoleService _consoleService;
        public BankManager(IConsoleService consoleService)
        {
            _consoleService = consoleService;
        }
        public void RunBankApplication()
        {
            var input = _consoleService.ReadLine();
            switch (input)
            {
                case "1":
                    _consoleService.WriteLine("Enter Account Number: ");
                    break;
                case "2":
                    _consoleService.WriteLine("Hello World!");
                    break;
                default:
                    break;
            }
        }
    }
