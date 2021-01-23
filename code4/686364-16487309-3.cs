    public partial class InGameMenu : UserControl
    {
        public InGameMenu()
        {
            InitializeComponent();
        }
        private void btnLoadSaved_Click(object sender, EventArgs e)
        {
            GameController.Instance.LoadSavedGame("test");
        }
    }
