    public partial class MyPopupWindow : Form
    {
        public MyPopupWindow()
        {
            InitializeComponent();
        }
        public string CounterText
        {
            set { labelCounter.Text = value; }
        }
    }
