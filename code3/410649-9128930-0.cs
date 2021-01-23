    public class MyCtrl : ItemsControl
    {
        static MyCtrl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCtrl), new FrameworkPropertyMetadata(typeof(MyCtrl)));
        }
    }
