    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SyncListToTextBox();
        }
        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SyncListToTextBox();
            }
        }
        private void SyncListToTextBox() 
        {
            this.textBox1.Text = this.listBox1.SelectedItem.ToString();
        }
    }
