    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerAsync();
        }
        delegate void Temp();
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            Temp temp = new Temp(UpdateTextBox);
            while (true)
            {
                Thread.Sleep(1000);
                textBox1.BeginInvoke(temp);
            }
        }
        void UpdateTextBox()
        {
            textBox1.Text += "+";
        }
    }
