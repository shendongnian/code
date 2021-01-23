    public class TreeViewItemCommandBehaviour
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command",
                                                typeof (ICommand),
                                                typeof (TreeViewItemCommandBehaviour),
                                                new UIPropertyMetadata(OnCommandChanged));
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter",
                                                typeof (object),
                                                typeof (TreeViewItemCommandBehaviour),
                                                new UIPropertyMetadata(null));
        public static void SetCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(CommandProperty, value);
        }
        public static ICommand GetCommand(DependencyObject target)
        {
            return (ICommand) target.GetValue(CommandProperty);
        }
        public static void SetCommandParameter(DependencyObject target, object value)
        {
            target.SetValue(CommandParameterProperty, value);
        }
        public static object GetCommandParameter(DependencyObject target)
        {
            return target.GetValue(CommandParameterProperty);
        }
        private static void OnCommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            var tvi = target as TreeViewItem;
            if (tvi == null) return;
            if ((e.NewValue != null) && (e.OldValue == null))
            {
                tvi.Selected += OnSelected;
            }
            else if ((e.NewValue == null) && (e.OldValue != null))
            {
                tvi.Selected -= OnSelected;
            }
        }
        private static void OnSelected(object sender, RoutedEventArgs e)
        {
            var tvi = sender as TreeViewItem;
            if (tvi == null) return;
            var command = GetCommand(tvi);
            var commandParameter = GetCommandParameter(tvi);
            command.Execute(commandParameter);
        }
    }
