    class MouseLeftButtonUpBehavior : Behavior<Control> {
      public static readonly DependencyProperty CommandProperty
        = DependencyProperty.Register(
          "Command",
          typeof(ICommand),
          typeof(MouseLeftButtonUpBehavior)
        );
      public ICommand Command
      {
        get { return (ICommand) GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
      }
      protected override void OnAttached() {
        AssociatedObject.MouseLeftButtonUp += OnMouseLeftButtonUp;
      }
      protected override void OnDetaching() {
        AssociatedObject.MouseLeftButtonUp -= OnMouseLeftButtonUp;
      }
      void OnMouseLeftButtonUp(Object sender, MouseButtonEventArgs mouseButtonEventArgs) {
        if (Command != null)
          Command.Execute(mouseButtonEventArgs);
      }
    }
