    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var result = new Form2().ShowDialog();
            MessageBox.Show(result.ToString());
        }
    }
    public partial class Form2 : Form
    {
        ButtonResult buttonResult;
        public Form2()
        {
            InitializeComponent();
        }
        public new ButtonResult ShowDialog()
        {
            base.ShowDialog();
            return buttonResult;
        }
        private void KeepButton_Click(object sender, EventArgs e)
        {
            buttonResult = ButtonResult.Keep;
            this.Close();
        }
        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            buttonResult = ButtonResult.Replace;
            this.Close();
        }
    }
    public enum ButtonResult
    {
        None = 0,
        Keep = 1,
        Replace = 2,
    }
