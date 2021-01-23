    using System.Timers;
    namespace Ariport_Parking
    {
      public partial class AirportParking : Form
      {
        //instance variables of the form
        System.Timers.Timer myTimer;
        private const string EvenText = "hello";
        private const string OddText = "hello world";
        private int tickLength = 100; 
        private int elapsedCounter;
        private int MaxTime = 5000;
        private int elapsedTime = 0;
        private readonly DateTime startTime = DateTime.Now; 
        public AirportParking()
        {
            InitializeComponent();
            lblValue.Text = EvenText; //"hello"; //EvenText;
            keepingTime();
        }
        //method for keeping time
        public void keepingTime() {
            myTimer = new System.Timers.Timer(tickLength);
            myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            myTimer.AutoReset = true;
            myTimer.Enabled = true;
            myTimer.Start();
            
        }
        
        private void myTimer_Elapsed(Object myObject,EventArgs myEventArgs){
            elapsedCounter++;
            elapsedTime += tickLength; 
            if (elapsedTime < MaxTime) 
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    this.lblElapsedTime.Text = elapsedTime.ToString();
                    if (elapsedCounter % 2 == 0)
                        this.lblValue.Text = EvenText;
                    else
                        this.lblValue.Text = OddText;
                })); 
            } 
        }
      }
    }
