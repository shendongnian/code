    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                for (int x = 0; x < 100000000; x++)
                {
                    label1.Invoke(new Action(() =>
                        label1.Text = x.ToString()));
                }
            });
        }
    }
