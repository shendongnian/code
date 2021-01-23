    public static readonly DependencyProperty AllowCustomSortProperty =
            DependencyProperty.RegisterAttached("AllowCustomSort", 
            typeof(bool),
            typeof(CustomSortBehaviour), // <- Here
            new UIPropertyMetadata(false, OnAllowCustomSortChanged));
        public static readonly DependencyProperty CustomSorterProperty =
            DependencyProperty.RegisterAttached("CustomSorter", 
            typeof(ICustomSorter), 
            typeof(CustomSortBehaviour));  // <- Here
