    public partial class Form1 : Form
    {
        UserControl2 mySecondControl = new UserControl2();
        public Form1()
        {
            InitializeComponent();
            userControl11.AddControl+=new EventHandler(SwapControls);
           
        }
        private void SwapControls(object sender, EventArgs e)
        {
            panel1.Controls.Remove(userControl11);
            userControl11.AddControl -= new EventHandler(SwapControls);
            panel1.Controls.Add(mySecondControl);
        }
    }
