     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                _Form1 = this;
            }
            public static Form1 _Form1;
            public void AddItem(object value)
            {
                listBox1.Items.Add(value);
            }
            private void button1_Click(object sender, EventArgs e)
            {
               Form2 _Form2 = new Form2();
              _Form2.Show();
            }
        }
