    public static readonly DependencyProperty PowerUserOnlyProperty =
        DependencyProperty.RegisterAttached(
            "PowerUserOnly", 
            typeof(bool), 
            typeof(App), 
            new UIPropertyMetadata(false, new PropertyChangedCallback(PUOChanged)));
    public static bool GetPowerUserOnly(MenuItem obj)
    {
        return (bool)obj.GetValue(PowerUserOnlyProperty);
    }
    public static void SetPowerUserOnly(MenuItem obj, bool value)
    {
        obj.SetValue(PowerUserOnlyProperty, value);
    }
    public static void PUOChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        MenuItem menuItem = sender as MenuItem;
        if (menuItem == null) return;
        bool value = (bool)e.NewValue;
        if (!value) return;
        new PowerUserOnlyHelper(menuItem);
    }
    public class PowerUserOnlyHelper
    {
        public MenuItem Item { get; protected set; }
        public PowerUserOnlyHelper(MenuItem menuItem)
        {
            Item = menuItem;
            ContextMenu parent = VisualUpwardSearch<ContextMenu>(menuItem);
            if (parent != null)
            {
                parent.Opened += new RoutedEventHandler(OnContextMenuOpened);
            }
        }
        protected void OnContextMenuOpened(object sender, RoutedEventArgs e)
        {
            Visibility v;
            if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                v = Visibility.Visible;
            }
            else v = Visibility.Collapsed;
            Item.Visibility = v;
        }
    }
    public static T VisualUpwardSearch<T>(DependencyObject source)
        where T : DependencyObject
    {
        DependencyObject returnVal = source;
        DependencyObject tempReturnVal;
        while (returnVal != null && !(returnVal is T))
        {
            tempReturnVal = null;
            if (returnVal is Visual || returnVal is Visual3D)
            {
                tempReturnVal = VisualTreeHelper.GetParent(returnVal);
            }
            if (tempReturnVal == null)
            {
                returnVal = LogicalTreeHelper.GetParent(returnVal);
            }
            else
            {
                returnVal = tempReturnVal;
            }
        }
        return returnVal as T;
    }
