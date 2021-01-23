    public class BackgroundJob
    {
        public event Action<object, int> StepCompleted;
        public void Execute()
        {
            const int TotalSteps = 10;
            for (int step = 1; step <= TotalSteps; step++)
            {
                Thread.Sleep(1000);
                int percentage = (int)(step * 100.0 / TotalSteps);
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
