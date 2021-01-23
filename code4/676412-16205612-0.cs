    public partial class UserControl1 : UserControl
    {
        public event EventHandler ClassificationClicked;
        public UserControl1()
        {
            InitializeComponent();
        }
        private void btnClassification_Click(object sender, EventArgs e)
        {
            ClassificationClicked(sender, e);
        }
    }
