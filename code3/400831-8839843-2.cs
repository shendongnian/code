    public partial class FirstForm : Form
    {
        private FormSwitcher switcher;
        public FirstForm()
        {
            InitializeComponent();
            switcher = new FormSwitcher(() => new FirstForm());
            switcher.AddForm(() => new SecondForm(switcher));
            switcher.AddForm(() => new ThirdForm(switcher));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switcher.GetNextForm().Show();
            Close();
        }
    }
    public partial class SecondForm : Form
    {
        private FormSwitcher switcher;
        public SecondForm(FormSwitcher switcher)
        {
            InitializeComponent();
            this.switcher = switcher;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switcher.GetNextForm().Show();
            Close();
        }
    }
    public partial class ThirdForm : Form
    {
        private FormSwitcher switcher;
        public ThirdForm(FormSwitcher switcher)
        {
            InitializeComponent();
            this.switcher = switcher;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switcher.GetNextForm().Show();
            Close();
        }
    }
