    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Thread started";
            Counter c = new Counter(Print, Finished);
            new Thread(new ThreadStart(c.Count)).Start();
        }
        private void Print(int i)
        {
            if (InvokeRequired)
                Invoke(new Action<int>(Print), i);
            else
                textBox1.Text += i + "\r\n";
        }
        private void Finished()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(Finished));
            }
            else
            {
                label1.Text = "Thread finished";
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
        }
    }
    class Counter
    {
        private readonly Action<int> _output;
        private readonly Action _finished;
        
        public Counter(Action<int> output, Action finished)
        {
            _output = output;
            _finished = finished;
        }
        public void Count()
        {
            for (int i = 0; i < 1000; i++)
                _output(i);
            _finished();
        }
    }
