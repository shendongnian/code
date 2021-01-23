        public partial class New_Form : Form
        {
            private System.Windows.Forms.Timer formClosingTimer;
            public New_Form()
            {
                InitializeComponent();
            }
            private void OnPageLoad(object sender, EventArgs e)
            {
                formClosingTimer = new System.Windows.Forms.Timer();  // Creating a new timer 
                formClosingTimer.Tick += new EventHandler(CloseForm); // Defining tick event to invoke after a time period
                formClosingTimer.Interval = 2000; // Time Interval in miliseconds
                formClosingTimer.Start(); // Starting a timer
            }
            private void CloseForm(object sender, EventArgs e)
            {
                formClosingTimer.Stop(); // Stoping timer. If we dont stop, function will be triggered in regular intervals
                this.Close(); // Closing the current form
            }
        }
