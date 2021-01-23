    public partial class Form1 : Form, ITextChange
    {
        public event EventHandler SomeTextChanged = delegate { };
        public Form1 () {}
        private void button1_Click(object sender, EventArgs e)
        {
            SomeTextChanged(textBox1.Text, null);
        }
    }
