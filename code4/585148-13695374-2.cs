    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            class1.DoSomething(OnSuccess, OnError);
        }
    
        private void OnSuccess(string newValue)
        {
            textBox1.Text = newValue;
        }
    
        private void OnError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
