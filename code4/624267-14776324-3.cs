    using System.Collections.Generic;
    using System.Windows;
    namespace ListBoxFitItemsPanel
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
            public IEnumerable<Item> Items
            {
                get
                {
                    for (int i = 0; i < 9; i++)
                    {
                        yield return new Item();
                    }
                }
            }
        }
        public class Item { }
    }
