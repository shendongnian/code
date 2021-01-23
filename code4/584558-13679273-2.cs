     public partial class Form1 : Form
     {
        public Form1()
        {
            InitializeComponent();
        }
 
        public System.Timers.Timer aTimer;
        public void BtnGenData_Click(object sender, EventArgs e)
        {
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
        }
         public void OnTimedEvent(object source, ElapsedEventArgs e)
         {
            this.TboxData.AppendText("Welcome");
         } 
     }
