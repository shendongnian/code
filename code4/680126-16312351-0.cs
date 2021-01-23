    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Logic logic = new Logic();
            logic.Progress += new Logic.ProgressDelegate(DisplayProgess);
            logic.Start();
        }
        public void DisplayProgess(string message, int percent)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Logic.ProgressDelegate(DisplayProgess), new Object[] { message, percent });
            }
            else
            {
                this.label1.Text = message;
                this.progressBar1.Value = percent;
            }
        }
    }
    public class Logic
    {
        private System.Threading.Thread T = null;
        public delegate void ProgressDelegate(string message, int percent);
        public event ProgressDelegate Progress;
        public void Start()
        {
            if (T == null)
            {
                T = new System.Threading.Thread(new System.Threading.ThreadStart(Worker));
                T.Start();
            }
        }
        private void Worker()
        {
            RaiseProgress("Initializing...", 0);
            System.Threading.Thread.Sleep(1000); // simulated work
            RaiseProgress("Loading Map...", 25);
            System.Threading.Thread.Sleep(1500); // simulated work
            RaiseProgress("Loading Sprites...", 50);
            System.Threading.Thread.Sleep(1200); // simulated work
            RaiseProgress("Loading Sound Effects...", 75);
            System.Threading.Thread.Sleep(1700);
            RaiseProgress("Loading Music...", 85);
            System.Threading.Thread.Sleep(1100); // simulated work
            RaiseProgress("Done!", 100);
        }
        private void RaiseProgress(string message, int percent)
        {
            if (Progress != null)
            {
                Progress(message, percent);
            }
        }
    }
