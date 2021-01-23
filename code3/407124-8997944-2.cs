    public partial class TimerCTR : Form
    {
        System.Timers.Timer timerInstance;
        int counter;
        public TimerCTR()
        {
            InitializeComponent();
            //Declare new timer instance.
            timerInstance = new System.Timers.Timer();
            //Set the interval
            timerInstance.Interval = TimeSpan.FromMilliseconds( 20 ).TotalMilliseconds;
            //Bind the event for the timer fired based on the interval
            timerInstance.Elapsed += new System.Timers.ElapsedEventHandler( timerInstance_Elapsed );
            //Start the timer.
            timerInstance.Start();
        }
        void timerInstance_Elapsed( object sender, System.Timers.ElapsedEventArgs e )
        {
            Thread.Sleep( 5000 );
        }
        private void button1_Click( object sender, EventArgs e )
        {
            counter += 1;
            if( counter == 30 )
                MessageBox.Show( counter.ToString() );
        }
    }
