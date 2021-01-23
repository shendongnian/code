    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                autoComplete.Add(textBox1.Text);
                
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //auto.Add(textBox1.Text);
                textBox1.AutoCompleteCustomSource = autoComplete;
            }
        }
    }
