    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void BeginAnimation()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = -textBlock1.ActualHeight;
            doubleAnimation.To = canvas1.ActualHeight;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(3));
            textBlock1.BeginAnimation(Canvas.TopProperty, doubleAnimation);
        }
    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BeginAnimation();
        }
    }
