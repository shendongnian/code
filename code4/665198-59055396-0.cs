    public partial class MainWindow : Window
    {
        // [...]
        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            AnimateWindowLeft(500, TimeSpan.FromSeconds(1));
        }
        private void AnimateWindowLeft(double newLeft, TimeSpan duration)
        {
            DoubleAnimation animation = new DoubleAnimation(newLeft, duration);
            myWindow.Completed += AnimateLeft_Completed;
            myWindow.BeginAnimation(Window.LeftProperty, animation);
        }
        private void AnimateLeft_Completed(object sender, EventArgs e)
        {
            myWindow.BeginAnimation(Window.LeftProperty, null);
            // or
            // myWindow.ApplyAnimationClock(Window.LeftProperty, null);
        }
    }
