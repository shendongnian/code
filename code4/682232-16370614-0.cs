    public partial class Form1 : Form
    {
        private DateTime dt;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetInitialTimer();
        }
        private void SetInitialTimer()
        {
            // Set "dt" to the BEGINNING of the CURRENT hour:
            dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
            switch (nud.Value.ToString())
            {
                case "0.5":
                case "1.5":
                case "2.5":
                case "3.5":
                case "4.5":
                case "5.5":
                    // start at the NEXT 1/2 hour or top of the hour:
                    if (DateTime.Now.Minute < 30)
                    {
                        dt = dt.AddMinutes(30);
                    }
                    else
                    {
                        dt = dt.AddHours(1);
                    }
                    break;
                default: // "1", "2", "3", "4", "5", "6"
                    // start at the TOP of the NEXT hour:
                    dt = dt.AddHours(1);
                    break;
            }
            timer1.Interval = (int)dt.Subtract(DateTime.Now).TotalMilliseconds;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            // ... do something in here ...
            SetRecurringTimer();
        }
        private void SetRecurringTimer()
        {
            dt = dt.AddMinutes((double)(nud.Value * (decimal)60));
            timer1.Interval = (int)dt.Subtract(DateTime.Now).TotalMilliseconds;
            timer1.Start();
        }
    }
