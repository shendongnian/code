    public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                new Form2 {FormOne = this}.ShowDialog();
            }
    
    
            public void SetLabelText(string text)
            {
                label1.Text = text;
            }
    
        }
