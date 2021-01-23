    public partial class Form1 : Form
    {
        private Clock Clk;
        public Form1()
        {
            InitializeComponent();
            Clk = new Clock();
            Clk.CurrentTime += new Clock.TimeHack(Clk_CurrentTime);
        }
        private void Clk_CurrentTime(string hack)
        {
            if (label1.InvokeRequired)
            {
                Clock.TimeHack t = new Clock.TimeHack(Clk_CurrentTime);
                label1.Invoke(t, new object[] { hack });
            }
            else
            {
                label1.Text = hack;
            }
        }
    }
    public class Clock
    {
        public delegate void TimeHack(string hack);
        public event TimeHack CurrentTime;
        private Thread t;
        private bool stopThread = false;
        public Clock()
        {
            t = new Thread(new ThreadStart(ThreadLoop));
            t.IsBackground = true; // allow it to be shutdown automatically when the application exits
            t.Start();
        }
        private void ThreadLoop()
        {
            while (!stopThread)
            {
                if (CurrentTime != null)
                {
                    CurrentTime(DateTime.Now.ToString());
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            stopThread = true;
        }
    }
