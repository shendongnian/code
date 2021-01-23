    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ShowTableButton_Click(object sender, EventArgs e)
        {
            int a;
            int b;
            const int STOP = 11;
            for(a = 1; a < STOP; a++)
            {
                for(b = 1; b < STOP; b++)
                {
                    int value = a * b; 
                    multiplicationTableLabel.Text += String.Format("{0} * {1} = {2}     ", b, a, value);
                }
                multiplicationTableLabel.Text += "\n";
            }
        }
    }
}
