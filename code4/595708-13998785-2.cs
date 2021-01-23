    public partial class LeakTest : UserControl
    {
        public ICommand PopupCommand { get; private set; }
        
        public LeakTest()
        {
            InitializeComponent();
            PopupCommand = new DelegateCommand(arg =>
            {
                var child = new ChildWindow();
                child.Closed += (sender, args) =>
                {
                    System.Diagnostics.Debug.WriteLine("Closed window");
                };
                // when the window has loaded, close it and re-trigger the command
                child.Loaded += (sender, args) =>
                {
                    child.Close();
                    PopupCommand.Execute(null);
                };
                child.Show();
            });
        }
    }
