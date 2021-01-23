    public partial class buttonTest : UserControl
    {
        public event CustomClickEventHandler CustomClick;
        public buttonTest()
        {
            InitializeComponent();
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CustomClick(sender, e);
        }
    }
