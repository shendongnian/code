    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            // This collection is bound to the ListBox so there are items to select from.
            public ObservableCollection<object> Items
            {
                get { return (ObservableCollection<object>)GetValue(ItemsProperty); }
                set { SetValue(ItemsProperty, value); }
            }
            public static readonly DependencyProperty ItemsProperty =
                DependencyProperty.Register("Items", typeof(ObservableCollection<object>), typeof(MainWindow), new PropertyMetadata(null));
    
            // On double click of each item in the ListBox more items will be added to this collection.
            public ObservableCollection<object> GridItems
            {
                get { return (ObservableCollection<object>)GetValue(GridItemsProperty); }
                set { SetValue(GridItemsProperty, value); }
            }       
            public static readonly DependencyProperty GridItemsProperty =
                DependencyProperty.Register("GridItems", typeof(ObservableCollection<object>), typeof(MainWindow), new PropertyMetadata(null));
            
            public MainWindow()
            {
                InitializeComponent();
                
                // Some demo items so we can double click.
                Items = new ObservableCollection<object>();
                Items.Add("test item 1");
                Items.Add("test item 2");
                Items.Add("test item 3");
                Items.Add("test item 4");
                Items.Add("test item 5");
                Items.Add("test item 6");
                Items.Add("test item 7");
    
                GridItems = new ObservableCollection<object>();
            }
    
            private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                // These would be the entries from your database, I'm going to add random numbers.
                Random rnd = new Random();
    
                for (int i = 0; i < rnd.Next(5); i++)
                    GridItems.Add(rnd.Next(100));
            }
        }
    }
