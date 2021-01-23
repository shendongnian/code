    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            removeItems();
            if (listBox1.Items.Count == 0)
            {
                timer1.Stop();
            }
        }
        void removeItems()
        {
            MessageBox.Show("Hello from the removeMethod");
            listBox1.Items.RemoveAt(0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
