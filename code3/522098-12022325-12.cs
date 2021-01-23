    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myProperties.sti = "Hello";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 popup = new Form2();
            popup.ShowDialog();
            popup.Dispose(); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = myProperties.sti;
        }
    }
    public static class myProperties
    {
        public static string sti { get; set; } 
    }
