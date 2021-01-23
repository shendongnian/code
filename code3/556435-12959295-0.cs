    public sealed partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            this.InitializeComponent();
        }
        public string[] MyList
        {
            get { return new string[] { "One", "Two", "Three" }; }
        }
    }
