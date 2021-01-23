    [ContentProperty("MenuItems")]
    public partial class ButtonAndMenu: UserControl
    {
        public ObservableCollection<DependencyObject> MenuItems
        {
            get { return (ObservableCollection<DependencyObject>)GetValue(MenuItemsProperty); }
            set { SetValue(MenuItemsProperty, value); }
        }
        internal static readonly DependencyProperty MenuItemsProperty = DependencyProperty.Register(
            "MenuItems", typeof(ObservableCollection<DependencyObject>), typeof(ButtonAndMenu),
            new FrameworkPropertyMetadata(new ObservableCollection<DependencyObject>()));
    }
