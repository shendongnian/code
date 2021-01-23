    public partial class ChatControl : User Control
    {
        PopNotifications popNotification = new PopNotifications();
        --and other code
    }
    public ChatControl()
    {
        InitializeComponent();
        this.Loaded += new RoutedEventHandler(ChatControl _Loaded);
    }
    private void ChatControl _Loaded(object sender, RoutedEventArgs e)
    {
        Window parentWindow = Window.GetWindow(this);
        popNotification.Owner = parentWindow;
        popNotification.Top = popNotification .Owner.Top;
        popNotification.Left = popNotification .Owner.Left;
        popNotification.WindowStartupLocation = WindowStartupLocation.Manual;
    }
