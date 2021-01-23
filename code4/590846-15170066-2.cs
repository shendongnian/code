    public static class ExtendedContextMenu
    {
        private static readonly StyleSelector _styleSelector = new ContextMenuItemStyleSelector();
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.RegisterAttached("Items",
                                                typeof(IEnumerable<MenuItemVM>),
                                                typeof(ExtendedContextMenu),
                                                new FrameworkPropertyMetadata(default(IEnumerable<MenuItemVM>), ItemsChanged));
        public static void SetItems(DependencyObject element, IEnumerable<MenuItemVM> value)
        {
            element.SetValue(ItemsProperty, value);
        }
        public static IEnumerable<MenuItemVM> GetItems(DependencyObject element)
        {
            return (IEnumerable<MenuItemVM>)element.GetValue(ItemsProperty);
        }
        private static void ItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (FrameworkElement)d;
            var items = (IEnumerable<MenuItemVM>)e.NewValue;
            var contextMenu = new ContextMenu();
            contextMenu.ItemContainerStyleSelector = _styleSelector;
            contextMenu.ItemsSource = items;
            return contextMenu;
        }
        private static void AdjustContextMenuVisibility(ContextMenu menu)
        {
            menu.Visibility = menu.HasItems ? Visibility.Visible : Visibility.Hidden;
        }
    }
    public class ContextMenuItemStyleSelector : StyleSelector
    {
        private static readonly MenuResourcesDictionary _resources = new MenuResourcesDictionary();
        private static readonly Style _menuItemStyle = (Style)_resources[MenuResourcesDictionary.MenuItemStyleResourceKey];
        private static readonly Style _separatorStyle = (Style)_resources[MenuResourcesDictionary.SeparatorStyleResourceKey];
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item == MenuItemVM.Separator)
                return _separatorStyle;
            return _menuItemStyle;
        }
    }
    public sealed partial class MenuResourcesDictionary
    {
        public const string MenuItemStyleResourceKey = "MenuItemStyleResourceKey";
        public const string DynamicMenuItemStyleResourceKey = "DynamicMenuItemStyleResourceKey";
        public const string SeparatorStyleResourceKey = "SeparatorStyleResourceKey";
        public const string LoadingStyleResourceKey = "LoadingMenuItemStyleResourceKey";
        public MenuResourcesDictionary()
        {
            InitializeComponent();
        }
    }
