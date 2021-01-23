    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // raise selection change event even when there's no change in index
            EventManager.RegisterClassHandler(typeof(ComboBoxItem), UIElement.PreviewMouseLeftButtonDownEvent,
                                              new MouseButtonEventHandler(ComboBoxSelfSelection), true);
            base.OnStartup(e);
        }
        private static void ComboBoxSelfSelection(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ComboBoxItem;
            if (item == null) return;
            // find the combobox where the item resides
            var comboBox = ItemsControl.ItemsControlFromItemContainer(item) as ComboBox;
            if (comboBox == null) return;
            // fire SelectionChangedEvent if two value are the same
            if ((string)comboBox.SelectedValue == (string)item.Content)
            {
                comboBox.IsDropDownOpen = false;
                comboBox.RaiseEvent(new SelectionChangedEventArgs(Selector.SelectionChangedEvent, new ListItem(), new ListItem()));
            }
        }
    }
