    namespace StackOverflow.WinForms
    {
        using System;
        using System.Windows.Forms;
        public class TimeCalculate
        {
            private Timer timer;
            private string theTime;
            public string TheTime
            {
                get
                {
                    return theTime;
                }
                set
                {
                    theTime = value;
                    OnTheTimeChanged(this.theTime);
                }
            }
            public TimeCalculate()
            {
                timer = new Timer();
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Interval = 1000;
                timer.Start();
            }
            private void Timer_Tick(object sender, EventArgs e)
            {
                TheTime = DateTime.UtcNow.ToString("dd/mm/yyyy HH:mm:ss");
            }
            public delegate void TimerTickHandler(string newTime);
            public event TimerTickHandler TheTimeChanged;
            protected void OnTheTimeChanged(string newTime)
            {
                if (TheTimeChanged != null)
                {
                    TheTimeChanged(newTime);
                }
            }
        }
    }
