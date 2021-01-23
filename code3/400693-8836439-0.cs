    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new System.Timers.Timer();
            timer.Interval = 3000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            textBox1.GotFocus += new EventHandler(textBox1_GotFocus);
            textBox1.LostFocus += new EventHandler(textBox1_LostFocus);
        }
        void textBox1_LostFocus(object sender, EventArgs e)
        {
            timer.Stop();
        }
        void textBox1_GotFocus(object sender, EventArgs e)
        {
            timer.Start();
        }
        void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            MessageBox.Show("You have not entered text in the last 3 seconds!");
        }
    }
