    namespace WindowsFormsApplication2
    {
        public partial class Form2 : Form
        {
            public ListViewAddDelegate deleg;
            public Form2()
            {
                InitializeComponent();
            }
            public Form2(ListViewAddDelegate delegObj)
            {
                this.deleg = delegObj;
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (!textBox1.Text.Equals(""))
                {
                    deleg(textBox1.Text);
                }
                else
                {
                    MessageBox.Show("Text can not be emopty");
                }
    
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
    
            }
        }
    }
