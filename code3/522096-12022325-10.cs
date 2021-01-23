    public partial class Form1 : Form
    {
        public string sti { get; set; } 
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 popup = new Form2();
            popup.ShowDialog();
            sti  = popup.sti;
            popup.Close();
            popup.Dispose(); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = sti;
        }
        
    }
