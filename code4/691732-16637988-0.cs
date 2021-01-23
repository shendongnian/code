    public partial class SomeUserControl : UserControl
    {
        public event ButtonPressedDelegate ButtonPressed;
        public delegate void ButtonPressedDelegate(SomeUserControl sender);
        public SomeUserControl()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ButtonPressed != null)
            {
                ButtonPressed(this); // pass the UserControl out as the parameter
            }
        }
    }
