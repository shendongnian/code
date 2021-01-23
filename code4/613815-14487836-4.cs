    public static class ProgressBarExtensions
    {
        private static TimeSpan duration = TimeSpan.FromSeconds(2);
        public static void SetPercent(this ProgressBar progressBar, double percentage)
        {
            DoubleAnimation animation = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, animation);          
        }
    }
