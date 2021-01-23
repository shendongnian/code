    public partial class Form3 : Form
    {
        volatile bool clDoSomething;
     
        public Form3()
        {
            InitializeComponent();
        }
        private void DoSomething()
        {
            int i = 0;
            clDoSomething = true;
            while(clDoSomething)
            {
                Application.DoEvents();
                ++i;
                Thread.Sleep(10);
                label1.Text = i.ToString();
                dataGridView1.Rows.Add();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DoSomething();
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            clDoSomething = false;
            Form1.Default.Show();
        }
       
    }
