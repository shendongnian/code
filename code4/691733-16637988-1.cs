    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            someUserControl1.ButtonPressed += new SomeUserControl.ButtonPressedDelegate(SomeUserControl_ButtonPressed);
            someUserControl2.ButtonPressed += new SomeUserControl.ButtonPressedDelegate(SomeUserControl_ButtonPressed);
            someUserControl3.ButtonPressed += new SomeUserControl.ButtonPressedDelegate(SomeUserControl_ButtonPressed);
        }
        void SomeUserControl_ButtonPressed(SomeUserControl sender)
        {
            // do something with "sender":
            sender.BackColor = Color.Red;
        }
    }
