        public partial class Form1 : Form
    {
        WebBrowser wb = new WebBrowser();
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(wb);
            wb.Dock = DockStyle.Fill;
            Load += OnLoad;
        }
        private void OnLoad(object sender, EventArgs eventArgs)
        {
            wb.Navigate("http://www.google.de");
        }
    }
