    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Members
        private readonly ViewModel _vm;
        #endregion
        public MainWindow()
        {
            // Get viewmodel and set context
            _vm = new ViewModel();
            this.DataContext = _vm;
            
            // Initialize UI
            InitializeComponent();
        }
        /// <summary>
        /// Moves selected items in a list from one collection to another.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        private void MoveItems(ListBox list, 
            ObservableCollection<string> source, 
            ObservableCollection<string> destination)
        {
            if (list.SelectedItems.Count > 0)
            {
                // List for items to be removed.
                var hitList = new List<string>();
                // Move items
                foreach (var selectedItem in list.SelectedItems)
                {
                    var item = selectedItem as string;
                    if (item != null)
                    {
                        // Tag item for removal
                        hitList.Add(item);
                        // Check if item is in target list
                        var targetList = (from p in destination
                                          where p == item
                                          select p).ToList();
                        // Add to destination
                        if (!targetList.Any())
                        {
                            destination.Add(item);
                        }
                    }
                }
                // Remove items
                foreach (var hitItem in hitList)
                {
                    // Remove item
                    source.Remove(hitItem);
                }
            }
        }
        /// <summary>
        /// Moves all items from one list to another.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        private void MoveAllItems(
            ObservableCollection<string> source,
            ObservableCollection<string> destination)
        {
            // List for items to be removed.
            var hitList = new List<string>();
            // Move items
            foreach (var item in source)
            {
                // Tag item for removal
                hitList.Add(item);
                // Check if item is in target list
                var targetList = (from p in destination
                                  where p == item
                                  select p).ToList();
                // Add to destination
                if (!targetList.Any())
                {
                    destination.Add(item);
                }
            }
            // Remove items
            foreach (var hitItem in hitList)
            {
                // Remove item
                source.Remove(hitItem);
            }
        }
        /// <summary>
        /// Click event: moves selected items to the right.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveRightEvent(object sender, RoutedEventArgs e)
        {
            MoveItems(List1, _vm.Collection1, _vm.Collection2);
        }
        /// <summary>
        /// Click event: moves all items to the right..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveAllRightEvent(object sender, RoutedEventArgs e)
        {
            MoveAllItems(_vm.Collection1, _vm.Collection2);
        }
        /// <summary>
        /// Click event: moves all items to the left.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveAllLeftEvent(object sender, RoutedEventArgs e)
        {
            MoveAllItems(_vm.Collection2, _vm.Collection1);
        }
        /// <summary>
        /// Click event: moves selected items to the left.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveLeftEvent(object sender, RoutedEventArgs e)
        {
            MoveItems(List2, _vm.Collection2, _vm.Collection1);
        }
    }
