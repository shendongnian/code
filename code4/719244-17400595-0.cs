        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt = new DateTime(2011, 1, 1, 0, 0, 0);
                Timer1.Enabled = false;
                Timer1.Interval = 1000;
                Timer2.Enabled = false;
                Timer2.Interval = 1000 * 60 * MIN_PER_TEST; // set interval for a test, if it is changing, do this in Button1_click [startstop=="stop"] before setting Enabled = true
                startstop = "Stop";
            }
        }
        // end of the test came, do what you need to do in order to kill the student mood further more :)
        protected void Timer2_Tick(object sender, EventArgs e)
        {
            Button1_Click(sender, e); // simulate clicking STOP, though might want to replace that!
        }
        // Added start and stop for the test duration timer.
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (startstop == "Stop")
            {
                startstop = "Start";
                Timer1.Enabled = true;
                Timer2.Enabled = true;
                Button1.Text = "Stop";
            }
            else
            {
                startstop = "Stop";
                Timer1.Enabled = false;
                Timer2.Enabled = false;
                Button1.Text = "Start";
            }
        }
