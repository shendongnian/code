    public partial class Form2 : Form
    {
        private static readonly Form2 _formInstance = new Form2();
        private Form2()
        {
            InitializeComponent();
        }
        private void LoadMeaning(string s)
        {
            label1.Text = s;
        }
        //Override method to prevent disposing the form when closing.
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        public static void ShowMeaning(string s)
        {
            _formInstance.LoadMeaning(s);
            _formInstance.Show();
        }
    }
