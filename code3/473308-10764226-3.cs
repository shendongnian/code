    public class MyControl : ...
    {
        public static readonly DependencyProperty SomethingProperty =
            DependencyProperty.Register(
                "Something", typeof(double), typeof(MyControl),
                new FrameworkPropertyMetadata(
                    (o, e) => ((MyControl)o).SomethingChanged((double)e.NewValue)));
        public double Something
        {
            get { return (double)GetValue(SomethingProperty); }
            set { SetValue(SomethingProperty, value); }
        }
        private void SomethingChanged(double newValue)
        {
            // process value changes here
        }
        ...
    }
