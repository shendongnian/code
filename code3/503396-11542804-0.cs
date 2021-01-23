    namespace design
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                listBox1.Items.Add(button1.Text); // This part is inside a event click of a button. This is why you can access this.
            }
            
            public void accessList()
            {
                listBox1.Items.Add(button1.Text); // You'll be able to access it here. Because you are inside a method.
            }
            // listBox1. // you'll NEVER access something like this. in this place
        }
    }
