    public partial class TitleScreen : UserControl
    {
        public TitleScreen()
        {
            InitializeComponent();
        }
        private void btnLoadNew(object sender, EventArgs e)
        {
            GameController.Instance.LoadNewGame();
        }
    }
