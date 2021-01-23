    public partial class ListContent
    {
        private ScrollViewer scrollViewer;
        public ListContent()
        {
            InitializeComponent();
            Loaded += OnLoaded();
        }
    
        protected virtual void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            scrollViewer = ControlHelper.List<ScrollViewer>(lbItems).FirstOrDefault();
            if (scrollViewer == null) return;
            FrameworkElement framework = VisualTreeHelper.GetChild(viewer, 0) as FrameworkElement;
            if (framework == null) return;
            VisualStateGroup group = FindVisualState(framework, "ScrollStates");
            if (group == null) return;
            group.CurrentStateChanged += OnListBoxStateChanged;
        }
        private VisualStateGroup FindVisualState(FrameworkElement element, string name)
        {
            if (element == null)
                return null;
            IList groups = VisualStateManager.GetVisualStateGroups(element);
            return groups.Cast<VisualStateGroup>().FirstOrDefault(@group => @group.Name == name);
        }
        private void OnListBoxStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            if (e.NewState.Name == ScrollState.NotScrolling.ToString())
            {
                // Check the ScrollableHeight and VerticalOffset here to determine
                // the position of the ListBox.
                // Add items, if the ListBox is at the end.
                // This event will fire when the listbox complete stopped it's 
                // scrolling animation
            }
        }
    }
