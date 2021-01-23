    // Used to store the counting value.
    private int _counter = 0;
    private void control_MouseHover(object sender, EventArgs e)
    {
        // Create a new Timer object.
        Timer timer = new Timer();
        // Set the timer's interval.
        timer.Interval = 1000;
        // Create the Tick-listening event.
        _timer.Tick += delegate(object sender, EventArgs e) 
        {
            // Update the counter variable.
            _counter++;
            // If the set time has reached, then show a MessageBox.
            if (_counter == 3) {
                MessageBox.Show("Three seconds have passed!");
            }
        };
        // Start the timer.
        _timer.Start();
    }
