    public partial class Form1 : Form
    {
        System.Timers.Timer  tmr = new System.Timers.Timer(1000);
        int timer;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            timer = 0;
            tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
            tmr.Start();
            while (timer < 2) ;
            tmr.Stop();
            Console.WriteLine("timer ends");
        }
        void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(timer);
            timer++;
        }
    }
