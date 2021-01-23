    [TestMethod]
    public void TestApplicationCurrentCultureInOtherThreads()
    {
        // Create the timer.
        using (var t = new System.Timers.Timer(2000))
        {
            // The task completion source.
            var tcs = new TaskCompletionSource<object>();
    
            // Captured name.
            CultureInfo capturedCulture = null;
    
            // Set the current culture.
            Application.CurrentCulture = new CultureInfo("en-GB");
    
            // Copy t.
            var tCopy = t;
    
            // Event handler.
            t.Elapsed += (s, e) => {
                // Stop the timer.
                tCopy.Stop();
    
                // What's the captured name.
                capturedCulture = CultureInfo.CurrentCulture;
    
                // Complete the task.
                tcs.SetResult(null);
            };
    
            // Start.
            t.Start();
    
            // Wait.
            tcs.Task.Wait();
    
            // Compare.
            Assert.AreNotEqual(CultureInfo.CurrentCulture, capturedCulture);
        }
    }
