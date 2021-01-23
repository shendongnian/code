    public class MainForm : Form
    {
        private Xpan _Xpan;
        public MainForm()
        {
            InitializeComponent();
            _Xpan = new Xpan();
        }
        private void SystemParametersClick(object sender, EventArgs e)
        {
            _Xpan.Show();
        }
    }
