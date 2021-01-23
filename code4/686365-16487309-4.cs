    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
            GameController.Instance.Model.DateChanged += Model_DateChanged;
            lblDate.Text = GameController.Instance.Model.DisplayDate;
        }
        void Model_DateChanged(object sender, EventArgs e)
        {
            lblDate.Text = GameController.Instance.Model.DisplayDate;
        }
        void Instance_CurrentGameChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            GameController.Instance.EndTurn();
        }
    }
