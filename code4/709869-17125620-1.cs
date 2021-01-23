    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string lastFolderSelected = Properties.Settings.Default.LastFolderSelected;
        }
    }
