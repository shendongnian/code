    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        private void button1_Click(object sender, EventArgs e)
        {
            new Task(DoTask).Start();
        }
        void DoTask()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(500);
                //here you need to update GUI through `Invoke` method
                //as the GUI may only be influenced from the the thread,
                //where it's created
                this.Invoke(new Action<int>((j) =>
                    {
                        button1.Text = j.ToString();
                    }), 10 * i);
            }
        }
    }
