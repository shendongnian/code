    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void DoSomething()
        {
            int i = 0;
            while ((true) && !this.IsDisposed)
            {
                    i++;
                    Thread.Sleep(10);
                    label1.Text = i.ToString();
                    dataGridView1.Rows.Add();
                    Application.DoEvents();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DoSomething();
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.Default.Show();
        }
       
    }
