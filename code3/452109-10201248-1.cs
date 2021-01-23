    public partial class AddNewItemButton : UserControl
    {
        ...
        #region Item Name
        public static readonly DependencyProperty ItemNameProperty = DependencyProperty.Register(
            "ItemName", typeof(string), typeof(AddNewItemButton),
            new FrameworkPropertyMetadata(OnItemNameChanged));
        public string ItemName
        {
            get { return (string)GetValue(ItemNameProperty); }
            set { SetValue(ItemNameProperty, value); }
        }
        public string ButtonText { get { return (string) tbItemName.Content; } }
        private static void OnItemNameChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            // When the item name changes, set the text of the item name
            var control = (AddNewItemButton)obj;
            control.tbItemName.Content = string.Format(GlobalCommandStrings.Subject_Add, control.ItemName.Capitalize());
            control.ToolTip = string.Format(GlobalCommandStrings.Subject_Add_ToolTip, control.ItemName);
        }
        #endregion
        #region Command
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(AddNewItemButton),
            new FrameworkPropertyMetadata(OnCommandChanged));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        private static void OnCommandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            // When the item name changes, set the text of the item name
            var control = (AddNewItemButton)obj;
            control.btnAddNewItem.Command = control.Command;
        }
        #endregion
    }
