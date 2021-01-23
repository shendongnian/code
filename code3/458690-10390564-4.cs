    public class TestViewModel
    {
        public TestViewModel()
        {
            var command = new ActionCommand(ShowHelp);
            Items = new List<TestItemViewModel>
                        {
                            new TestItemViewModel(command), 
                            new TestItemViewModel(command)
                        };
        }
        public IList<TestItemViewModel> Items { get; private set; }
        private void ShowHelp()
        {
            Debug.WriteLine("Help root");
        }
    }
    public class TestItemViewModel
    {
        public TestItemViewModel(ICommand helpCommand)
        {
            HelpCommand = helpCommand;
            Header = "header";
        }
        public ICommand HelpCommand { get; private set; }
        public string Header { get; private set; }
    }
