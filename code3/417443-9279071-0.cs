    public partial class Form1 : Form {
        private Thread threadProcess;
        private System.Windows.Forms.Timer heavyProcessTimer = new Timer();
        
        public Form1() {
            InitializeComponent();
            heavyProcessTimer.Interval = 50; // or whatever
            heavyProcessTimer.Tick += new EventHandler(heavyProcessTimer_Tick);
        }
        void heavyProcessTimer_Tick(object sender, EventArgs e) {
            if (!threadProcess.IsAlive) {
                heavyProcessTimer.Stop();
                MyListBox.Focus();    
                ShowResult(...);
            }
        }
        private void btnPress(object sender, EventArgs e) {
            SetStatus(" Openning & Initializing the File"); 
            ThreadStart threadStart = new ThreadStart(HeavyProcess); 
            threadProcess = new Thread(threadStart); 
            threadProcess.Start();
            heavyProcessTimer.Start();
        }
    }
