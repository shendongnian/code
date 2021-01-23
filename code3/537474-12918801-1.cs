     /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Things = new List<Thing>
                             {
                                 new Thing {ThingName = "t1"},
                                 new Thing {ThingName = "t2"},
                                 new Thing {ThingName = "t4"},
                                 new Thing {ThingName = "t3"},
                             };
                DataContext = this;
    
            }
    
            public List<Thing> Things { get; set; }
            public Thing SelectedThing { get; set; }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                var yourListViewItem = (ListViewItem)yourListView.ItemContainerGenerator.ContainerFromItem(yourListView.SelectedItem);
                CheckBox cb = FindByName("myCBox", yourListViewItem) as CheckBox;
                MessageBox.Show(cb.Content + " IsChecked :" + cb.IsChecked);
            }
            private FrameworkElement FindByName(string name, FrameworkElement root)
            {
                Stack<FrameworkElement> tree = new Stack<FrameworkElement>();
                tree.Push(root);
    
                while (tree.Count > 0)
                {
                    FrameworkElement current = tree.Pop();
                    if (current.Name == name)
                        return current;
    
                    int count = VisualTreeHelper.GetChildrenCount(current);
                    for (int i = 0; i < count; ++i)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(current, i);
                        if (child is FrameworkElement)
                            tree.Push((FrameworkElement)child);
                    }
                }
    
                return null;
            }
        }
    
    
    
        public class Thing
        {
            public string ThingName { get; set; }
    
        }
