    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        private void button1_Click(object sender, EventArgs e)
        {
            new Task(Task).Start();
        }
        void Task()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(500);
                this.Invoke(new Action<int>((j) =>
                    {
                        button1.Text = j.ToString();
                    }), 10 * i);
            }
        }
    }
