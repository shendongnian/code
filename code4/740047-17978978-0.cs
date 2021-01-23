    <Style TargetType="{x:Type local:BorderEx}">
        <EventSetter Event="Button.Click" Handler="ReloadClickEvent" />
    ...
    </Style>
Code behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }        
        private void ReloadClickEvent(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new DemoEventArgs(BorderEx.ReloadClickEvent, sender));
        }
    }
    public class DemoEventArgs : RoutedEventArgs
    {
        public DemoEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
            MessageBox.Show("Raise!");
        }
    }
    public sealed class BorderEx : Control
    {
        public static readonly RoutedEvent ReloadClickEvent = EventManager.RegisterRoutedEvent("ReloadClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BorderEx));
        public event RoutedEventHandler ReloadClick
        {
            add { AddHandler(ReloadClickEvent, value); }
            remove { RemoveHandler(ReloadClickEvent, value); }
        }
        private void RaiseReloadClickEvent()
        {
            var newEventArgs = new RoutedEventArgs(ReloadClickEvent);
            RaiseEvent(newEventArgs);
        }
        static BorderEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BorderEx), new FrameworkPropertyMetadata(typeof(BorderEx)));
        }
    }      
