    public class TestViewModel
    {
        public TestViewModel()
        {
            Items = new List<TestItemViewModel>{ 
                        new TestItemViewModel(), new TestItemViewModel() };
        }
        public ICommand HelpCommand { get; private set; }
        public IList<TestItemViewModel> Items { get; private set; }
    }
    public class TestItemViewModel
    {
        public TestItemViewModel()
        {
            // Expression Blend ActionCommand
            HelpCommand = new ActionCommand(ShowHelp);
            Header = "header";
        }
        public ICommand HelpCommand { get; private set; }
        public string Header { get; private set; }
        private void ShowHelp()
        {
            Debug.WriteLine("Help item");
        }
    }
