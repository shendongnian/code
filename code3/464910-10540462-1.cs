    public partial class MainWindow : Window
    {
        DoubleAnimation _animation;
        public MainWindow()
        {
            InitializeComponent();
            _animation = new DoubleAnimation();
            _animation.Duration = new Duration(TimeSpan.FromMilliseconds(150));
            _animation.FillBehavior = FillBehavior.HoldEnd;
        }
        private void Window_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            double x = _transform.X;
            _transform.BeginAnimation(TranslateTransform.XProperty, null);
            _transform.SetValue(TranslateTransform.XProperty, x);
            _animation.To = _transform.X + (e.Delta / 2);
            _transform.BeginAnimation(TranslateTransform.XProperty, _animation);
        }
    }
