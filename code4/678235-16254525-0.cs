     // code to filter out false signals
        DateTime lastTimeSignalReceived = DateTime.Now;
        double minimumTimeBetweenSignals = 4.9; // 12 rpm = 5 seconds between signals minimum
        int turns = 0;
        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            if (value == 1)
            {
                // the if statement is true only if at least 4.9 seconds has past since last signal
                // which should filter out false signals
                if ((DateTime.Now - lastTimeSignalReceived).TotalSeconds > minimumTimeBetweenSignals)
                {
                    // at least 4.9 seconds since last signal
                    textBox6.text = turns.ToString();
                    turns++;
                    // set lastTimeSignalReceived to new time
                    lastTimeSignalReceived = DateTime.Now;
                }
            }
        }
