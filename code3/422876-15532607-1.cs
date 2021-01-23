    using System.Windows;
    namespace WpfApplication2
    {
        /// <summary>
        /// The main window.
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                //DataContext = new Item { Description = "Item 1", SelectedIndex = 0 };
                DataContext = new DemoDataContext();
            }
        }
        /// <summary>
        /// An object with 'Items'.
        /// </summary>
        public sealed class DemoDataContext
        {
            readonly Item[] _items = new Item[] {
                new Item { Description = "Item 1", SelectedIndex = 0 },
                new Item { Description = "Item 2", SelectedIndex = 1 },
                new Item { Description = "Item 3", SelectedIndex = 2 },
            };
            public Item[] Items { get { return _items; } }
        }
        /// <summary>
        /// An object with a string and an int property.
        /// </summary>
        public sealed class Item
        {
            int _selectedIndex;
            string _description;
            public string Description
            {
                get { return _description; }
                set { _description = value; }
            }
            public int SelectedIndex
            {
                get { return _selectedIndex; }
                set { _selectedIndex = value; }
            }
        }
    }
