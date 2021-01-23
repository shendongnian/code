    public static class DoubleClick
    {
        public static readonly DependencyProperty CommandProperty =
                              DependencyProperty.RegisterAttached(
                                      "Command",
                                      typeof(ICommand),
                                      typeof(DoubleClick),
                                      new PropertyMetadata(OnSetCommandCallback));
        public static readonly DependencyProperty CommandParameterProperty =
                                DependencyProperty.RegisterAttached(
                                        "CommandParameter",
                                        typeof(object),
                                        typeof(DoubleClick),
                                        new PropertyMetadata(OnSetCommandParameterCallback));
    
        private static readonly DependencyProperty DoubleClickCommandBehaviorProperty =
                                      DependencyProperty.RegisterAttached(
                                              "DoubleClickCommandBehavior",
                                              typeof(ListViewItemDoubleClickCommandBehaviour),
                                              typeof(DoubleClick),
                                              null);
        public static void SetCommand(ListViewItem controlToWhomWeBind, ICommand value)
        {
            controlToWhomWeBind.SetValue(CommandProperty, value);
        }
        public static ICommand GetCommand(ListViewItem controlToWhomWeBind)
        {
             return (ICommand)controlToWhomWeBind.GetValue(CommandProperty);
        }
        public static void SetCommandParameter(ListViewItem controlToWhomWeBind, ICommand value)
        {
            controlToWhomWeBind.SetValue(CommandParameterProperty, value);
        }
        public static ICommand GetCommandParameter(ListViewItem controlToWhomWeBind)
        {
            return (ICommand)controlToWhomWeBind.GetValue(CommandParameterProperty);
        }
        private static void OnSetCommandCallback(DependencyObject dependencyObject,
    DependencyPropertyChangedEventArgs e)
        {
            ListViewItem controlToWhomWeBind= dependencyObject as ListViewItem;
            if (controlToWhomWeBind!= null)
            {
                ListViewItemDoubleClickCommandBehaviour behavior = GetOrCreateBehavior(controlToWhomWeBind);
                behavior.Command = e.NewValue as ICommand;
            }
        }
        private static void OnSetCommandParameterCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ListViewItem controlToWhomWeBind= dependencyObject as ListViewItem;
            if (controlToWhomWeBind!= null)
            {
                ListViewItemDoubleClickCommandBehaviour behavior = GetOrCreateBehavior(controlToWhomWeBind);
                behavior.CommandParameter = e.NewValue;
            }
        }
        private static ListViewItemDoubleClickCommandBehaviour GetOrCreateBehavior(
                                                                   ListViewItem controlToWhomWeBind)
        {
            ListViewItemDoubleClickCommandBehaviour behavior =
                controlToWhomWeBind.GetValue(DoubleClickCommandBehaviorProperty) as
                     ListViewItemDoubleClickCommandBehaviour;
            if (behavior == null)
            {
                behavior = new ListViewItemDoubleClickCommandBehaviour (controlToWhomWeBind);
                controlToWhomWeBind.SetValue(DoubleClickCommandBehaviorProperty, behavior);
            }
            return behavior;
        }
    }
