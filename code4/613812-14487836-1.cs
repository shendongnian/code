    public static class ProgressBarExtensions
    {
        public static void SetPercent(this ProgressBar progressBar, double percentage)
        {
            TimeSpan duration = TimeSpan.FromSeconds(2);
            DoubleAnimation animation = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, animation);          
        }
    }
