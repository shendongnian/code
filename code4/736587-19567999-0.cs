    public partial class ctlPickButton : UserControl
    {
        public event EventHandler pickButtonClicked;
        public ctlPickButton()
        {
            InitializeComponent();
        }
        //Allows buttons image to be set in code if necessary
        public Image Image
        {
            get
            {
                return button1.Image;
            }
            set
            {
                if (Image != null)
                {
                    button1.Image = value;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (pickButtonClicked != null)
            {
                pickButtonClicked(sender, e);
            }
        }
    }
