    // at the end of animation routine
    progressTransition.Completed += new EventHandler(progressFlyOut_Completed);
    progressTransition.Begin(ControlElement);
    // allow animation to complete
    WaitForCompletion(seconds * 2);
    // completion event
    private static void progressFlyOut_Completed(object sender, EventArgs e)
    {
        AnimationCompleted = true;
    }
        // wait routine
        private static void WaitForCompletion(double TimeOut)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            while (AnimationCompleted == false)
            {
                if (stopwatch.Elapsed.TotalSeconds > TimeOut)
                    break;
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => { })).Wait();
            }
            AnimationCompleted = false;
        }
