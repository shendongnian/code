    public enum UserInterfaceModes
    {
        Mouse,
        Touch,
    }
    public UserInterfaceModes UserInterfaceMode
    {
       get { return (UserInterfaceModes)GetValue(UserInterfaceModeProperty); }
       set { SetValue(UserInterfaceModeProperty, value); }
    }
    public static readonly DependencyProperty UserInterfaceModeProperty = DependencyProperty.Register("UserInterfaceMode", typeof(UserInterfaceModes), typeof(MainWindow), new UIPropertyMetadata(UserInterfaceModes.Mouse));
