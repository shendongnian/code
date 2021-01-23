    public static readonly DependencyProperty CommandProperty =
      DependencyProperty.Register(
        "Command", typeof(ICommand), typeof(UserControl1), new PropertyMetadata(null, OnCurrentCommandChanged));
    
    private static void OnCurrentCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
      UserControl1 currentUserControl = d as UserControl1;
      ICommand newCommand = e.NewValue as ICommand;
      if (currentUserControl == null || newCommand == null)
        return;
      newCommand.CanExecuteChanged += (o, args) => currentUserControl.IsEnabled = newCommand.CanExecute(null);
    }
    
    public ICommand Command {
      get {
        return (ICommand)GetValue(CommandProperty);
      }
      set {
        SetValue(CommandProperty, value);
      }
    }
