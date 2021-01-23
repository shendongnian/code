    public partial class ChildWindow : Window
    {
        private IListner Listner { get; set; }
        public ChildWindow(IListner listner)
        {
            InitializeComponent();
            Listner = listner;
        }
        private void OnTextBoxTextChanged()
        {
            // This will call "Send" on "MainWindow"
            Listner.Send(TextBox1.Text);
        }
    }
