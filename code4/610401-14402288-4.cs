    public partial class Test : UserControl
    {
        public Test()
        {
            InitializeComponent();
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.DoubleClick += Control_DoubleClick;
            base.OnControlAdded(e);
        }
        void Control_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("User control clicked");
            OnDoubleClick(e);
        }
    }
