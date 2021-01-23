    public partial class Form2 : Form
        CalculateValues myAdd; < ====
        MulitplyValues Add;    < ====
        public Form2()
        {   
            myAdd = new CalculateValues();   < ====             
            Add = new MulitplyValues();      < ====
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
    
            int total = myadd.Add(int.Parse(textBox1.Text), int.Parse(textBox2.Text));    
            MessageBox.Show(total.ToString());
    
        }
    }
    
