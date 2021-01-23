    private Task GetNextPeakAsync(CancellationToken token)
    {
        // Start in a new task.
        Task.Factory.StartNew(() => {
            // Cycle while there is no cancellation.
            while (!token.IsCancellationRequested)
            {
                cpuCounter = new PerformanceCounter("Processor", 
                    "% Processor Time", "_Total");
                double currentValue = cpuCounter.NextValue();
                if (currentValue > thisCPUPeak)
                {
                    thisCPUPeak = currentValue;
                }
                startStopButton.Dispatcher.Invoke((cv, p) => {
                    CurrentCPUPeak.Text = cv.ToString();
                    CPUPeak.Text = p.ToString();
                }, new object[] { currentValue, thisCPUPeak });
            }
        }, TaskCreationOptions.LongRunning);
    }
