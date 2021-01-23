    private Task GetNextPeakAsync(CancellationToken token)
    {
        // Start in a new task.
        return Task.Factory.StartNew(() => {
            // Store the counter outside of the loop.
            var cpuCounter = 
                new PerformanceCounter("Processor", "% Processor Time", "_Total");
            // Cycle while there is no cancellation.
            while (!token.IsCancellationRequested)
            {
                // Wait before getting the next value.
                Thread.Sleep(1000);
                // Get the next value.
                double currentValue = cpuCounter.NextValue();
                if (currentValue > thisCPUPeak)
                {
                    thisCPUPeak = currentValue;
                }
                // The action to perform.
                Action<double, double> a = (cv, p) => {
                    CurrentCPUPeak.Text = cv.ToString();
                    CPUPeak.Text = p.ToString();
                };
                startStopButton.Dispatcher.Invoke(a, 
                    new object[] { currentValue, thisCPUPeak });
            }
        }, TaskCreationOptions.LongRunning);
    }
