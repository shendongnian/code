    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Members
        private readonly ViewModel<TrackerItem> _vm;
        #endregion
        public MainWindow()
        {
            // Get viewmodel and set context
            _vm = new ViewModel<TrackerItem>();
            _vm.Collection1 = new ObservableCollection<TrackerItem>
                {
                    new TrackerItem { Name = "Item1", Value = "1"},
                    new TrackerItem { Name = "Item2", Value = "2"},
                    new TrackerItem { Name = "Item3", Value = "3"},
                    new TrackerItem { Name = "Item4", Value = "4"},
                    new TrackerItem { Name = "Item5", Value = "5"},
                    new TrackerItem { Name = "Item6", Value = "6"},
                    new TrackerItem { Name = "Item7", Value = "7"},
                    new TrackerItem { Name = "Item8", Value = "8"},
                    new TrackerItem { Name = "Item9", Value = "9"},
                    new TrackerItem { Name = "Item10", Value = "10"}
                };
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
            ObservableCollection<TrackerItem> source,
            ObservableCollection<TrackerItem> destination)
        {
            if (list.SelectedItems.Count > 0)
            {
                // List for items to be removed.
                var hitList = new List<TrackerItem>();
                // Move items
                foreach (var selectedItem in list.SelectedItems)
                {
                    var item = selectedItem as TrackerItem;
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
            ObservableCollection<TrackerItem> source,
            ObservableCollection<TrackerItem> destination)
        {
            // List for items to be removed.
            var hitList = new List<TrackerItem>();
            // Move items
            foreach (var item in source)
            {
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
