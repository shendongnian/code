    public partial class UserControl1 : UserControl
    {
        private int i;
        public UserControl1()
        {
            InitializeComponent();
        }
        public void AddStuff()
        {
            listBox1.Items.Add("This is line : " + i.ToString());
            i += 1;
        }
    }
