    public class MyView : UserControl
    {
        public static readonly DependencyProperty DevicesProperty = DependencyProperty.Register(
          "Devices",
          typeof(List<string>),
          typeof(MainWindow),
          new FrameworkPropertyMetadata(null));
        public List<string> Devices
        {
            get { return (List<string>)GetValue(DevicesProperty); }
            set { SetValue(DevicesProperty, value); }
        }
        ...
    }
