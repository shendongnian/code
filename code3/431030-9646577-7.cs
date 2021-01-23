    public class BackgroundJob
    {
        public event Action<object, int> StepCompleted;
        public void Execute()
        {
            const int TotalSteps = 10;
            for (int step = 1; step <= TotalSteps; step++)
            {
                // Execute some heavy work here.
                Thread.Sleep(1000);
                // Calculate percentage (0..100).
                int percentage = (int)(step * 100.0 / TotalSteps);
                // Notify the subscribers that the step has been completed.
                OnStepCompleted(percentage);
            }
        }
        protected virtual void OnStepCompleted(int percentage)
        {
            if (StepCompleted != null)
            {
                StepCompleted(this, percentage);
            }
        }
    }
