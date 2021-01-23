    public partial class WeeklyReportPlant : UserControl
    {
        public static readonly DependencyProperty UserSatisfiedProperty =
            DependencyProperty.Register(
                "UserSatisfied",
                typeof(bool?),
                typeof(WeeklyReportPlant),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnUserSatisfiedChanged)));
        private static void OnUserSatisfiedChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as WeeklyReportPlant;
        }
    }
