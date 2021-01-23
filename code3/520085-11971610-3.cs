    public class ItemsControlBehaviours
    {
        public static readonly DependencyProperty BlinkMainWindowOnItemsSourceChangeProperty =
            DependencyProperty.RegisterAttached(
                "BlinkMainWindowOnItemsSourceChange", typeof(bool), typeof(ItemsControlBehaviours),
                new PropertyMetadata(BlinkMainWindowOnItemsSourceChangePropertyChanged));
        public static bool GetBlinkMainWindowOnItemsSourceChange(ItemsControl itemsControl)
        {
            return (bool)itemsControl.GetValue(BlinkMainWindowOnItemsSourceChangeProperty);
        }
        public static void SetBlinkMainWindowOnItemsSourceChange(ItemsControl itemsControl, bool value)
        {
            itemsControl.SetValue(BlinkMainWindowOnItemsSourceChangeProperty, value);
        }
        private static void BlinkMainWindowOnItemsSourceChangePropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ItemsControl itemsControl = obj as ItemsControl;
            INotifyCollectionChanged collection;
            if (itemsControl != null &&
                (collection = itemsControl.ItemsSource as INotifyCollectionChanged) != null)
            {
                if ((bool)e.NewValue)
                {
                    collection.CollectionChanged += ItemsSourceCollectionChanged;
                }
                else
                {
                    collection.CollectionChanged -= ItemsSourceCollectionChanged;
                }
            }
        }
        private static void ItemsSourceCollectionChanged(
            object sender, NotifyCollectionChangedEventArgs e)
        {
            SolidColorBrush background =
                Application.Current.MainWindow.Background as SolidColorBrush;
            if (background != null)
            {
                ColorAnimation backgroundAnimation = new ColorAnimation
                {
                    To = Colors.Red,
                    Duration = TimeSpan.FromSeconds(1),
                    AutoReverse = true
                };
                background.BeginAnimation(
                    SolidColorBrush.ColorProperty, backgroundAnimation);
            }
        }
    }
