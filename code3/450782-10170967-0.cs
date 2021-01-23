    public partial class AirportParking : Form
    {
        private Timer myTimer = new Timer(100);
        private int elapsedCounter = 0;
        private readonly DateTime startTime = DateTime.Now;
        private const string EvenText = "hello";
        private const string OddText = "hello world";
        public AirportParking()
        {
            lblValue.Text = EvenText;
            myTimer.Elapsed += MyTimerElapsed;
            myTimer.AutoReset = true;
            myTimer.Enabled = true;
            myTimer.Start();
        }
        private void MyTimerElapsed(Object sender,EventArgs myEventArgs)
        {
            If (lblValue.InvokeRequired)
            {
                this.BeginInvoke(sender, myEventArgs);
                return;   
            }
            lock (this)
            {
                lblElapsedTime.Text = DateTime.Now.SubTract(startTime).ToString();
                elapesedCounter++;
                if(elapsedCounter % 2 == 0)
                {
                    lblValue.Text = EvenText;
                }
                else
                {
                    lblValue.Text = OddText;
                }
            }
        }
    }
