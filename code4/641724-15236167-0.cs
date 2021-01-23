    private void timer_Tick(object sender, EventArgs e)
    {
            if (someConditionToEndScroll) // you decide when to stop scrolling
            {
               Timer timer = (Timer) sender;
                
               timer.Stop();
               labelTesting.Left = 0; // or wherever it should be at the end of the scrolling
            }
            this.Refresh();
            labelTesting.Left += 5;
            if (labelTesting.Left >= this.Width)
            {
                labelTesting.Left = labelTesting.Width * -1;
            }           
    }
