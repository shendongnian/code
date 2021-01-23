     public partial class Form1 : Form
     {
        public Form1()
        {
            InitializeComponent();
            string[] array = { "aaa", "abc", "acc", "aac", "acc", "bcc", "cbb", "bbb" };
            //upper line iy my custom array, you get it from database
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(array);
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = autoComplete;
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //you can use this event to get some data:
            string item = textBox1.Text.Trim();
        }
    }
