    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void UiButtonOneClick(object sender, EventArgs e)
        {
            myUserControlOne.Show();
            myUserControlTwo.Hide();
        }
        private void UiButtonTwoClick(object sender, EventArgs e)
        {
            myUserControlOne.Hide();
            myUserControlTwo.Show();
        }
    }
