    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }
        private static InfoForm _instance;
        public static InfoForm Open()
        {
            if (_instance == null) {
                _instance = new InfoForm();
                _instance.Show();
            } else {
                _instance.BringToFront();
            }
            return _instance;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // Make sure _instance is null when form is closed
            _instance = null;
        }
        // Exposes the text of the infoBox
        public static string InfoText
        {
            get { return _instance == null ? null : _instance.infoBox.Text; }
            set { if (_instance != null) _instance.infoBox.Text = value; }
        }
    }
