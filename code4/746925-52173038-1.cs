    public static class DataGridColumnCollection
    {
        public static readonly DependencyProperty ColumnCollectionBehaviourProperty =
            DependencyProperty.RegisterAttached("ColumnCollectionBehaviour", typeof(DataGridColumnCollectionBehaviour), typeof(DataGridColumnCollection), new UIPropertyMetadata(null));
        public static readonly DependencyProperty ColumnsSourceProperty =
            DependencyProperty.RegisterAttached("ColumnsSource", typeof(object), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.ColumnsSourcePropertyChanged));
        public static readonly DependencyProperty DisplayMemberFormatMemberProperty =
            DependencyProperty.RegisterAttached("DisplayMemberFormatMember", typeof(string), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.DisplayMemberFormatMemberChanged));
        public static readonly DependencyProperty DisplayMemberMemberProperty =
            DependencyProperty.RegisterAttached("DisplayMemberMember", typeof(string), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.DisplayMemberMemberChanged));
        public static readonly DependencyProperty FontWeightBindingMemberProperty =
            DependencyProperty.RegisterAttached("FontWeightBindingMember", typeof(string), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.FontWeightBindingMemberChanged));
        public static readonly DependencyProperty FontWeightMemberProperty =
            DependencyProperty.RegisterAttached("FontWeightMember", typeof(string), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.FontWeightMemberChanged));
        public static readonly DependencyProperty IsEditableMemberProperty =
            DependencyProperty.RegisterAttached("IsEditableMember", typeof(string), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.IsEditableMemberChanged));
        public static readonly DependencyProperty HeaderTextMemberProperty =
            DependencyProperty.RegisterAttached("HeaderTextMember", typeof(string), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.HeaderTextMemberChanged));
        public static readonly DependencyProperty SortMemberProperty =
            DependencyProperty.RegisterAttached("SortMember", typeof(string), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.SortMemberChanged));
        public static readonly DependencyProperty TextAlignmentMemberProperty =
            DependencyProperty.RegisterAttached("TextAlignmentMember", typeof(string), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.TextAlignmentMemberChanged));
        public static readonly DependencyProperty TextColourMemberProperty =
            DependencyProperty.RegisterAttached("TextColourMember", typeof(string), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.TextColourMemberChanged));
        public static readonly DependencyProperty WidthMemberProperty =
            DependencyProperty.RegisterAttached("WidthMember", typeof(string), typeof(DataGridColumnCollection), new UIPropertyMetadata(null, DataGridColumnCollection.WidthMemberChanged));
        public static DataGridColumnCollectionBehaviour GetColumnCollectionBehaviour(DependencyObject obj)
        {
            return (DataGridColumnCollectionBehaviour)obj.GetValue(ColumnCollectionBehaviourProperty);
        }
        public static void SetColumnCollectionBehaviour(DependencyObject obj, DataGridColumnCollectionBehaviour value)
        {
            obj.SetValue(ColumnCollectionBehaviourProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        public static object GetColumnsSource(DependencyObject obj)
        {
            return (object)obj.GetValue(ColumnsSourceProperty);
        }
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        public static void SetColumnsSource(DependencyObject obj, ObservableCollection<DataGridColumn> value)
        {
            obj.SetValue(ColumnsSourceProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetDisplayMemberFormatMember(DependencyObject obj)
        {
            return (string)obj.GetValue(DisplayMemberFormatMemberProperty);
        }
        public static void SetDisplayMemberFormatMember(DependencyObject obj, string value)
        {
            obj.SetValue(DisplayMemberFormatMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetDisplayMemberMember(DependencyObject obj)
        {
            return (string)obj.GetValue(DisplayMemberMemberProperty);
        }
        public static void SetDisplayMemberMember(DependencyObject obj, string value)
        {
            obj.SetValue(DisplayMemberMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetFontWeightBindingMember(DependencyObject obj)
        {
            return (string)obj.GetValue(FontWeightBindingMemberProperty);
        }
        public static void SetFontWeightBindingMember(DependencyObject obj, string value)
        {
            obj.SetValue(FontWeightBindingMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetFontWeightMember(DependencyObject obj)
        {
            return (string)obj.GetValue(FontWeightMemberProperty);
        }
        public static void SetFontWeightMember(DependencyObject obj, string value)
        {
            obj.SetValue(FontWeightMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetTextAlignmentMember(DependencyObject obj)
        {
            return (string)obj.GetValue(TextAlignmentMemberProperty);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static void SetTextAlignmentMember(DependencyObject obj, string value)
        {
            obj.SetValue(TextAlignmentMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetTextColourMember(DependencyObject obj)
        {
            return (string)obj.GetValue(TextColourMemberProperty);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static void SetTextColourMember(DependencyObject obj, string value)
        {
            obj.SetValue(TextColourMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        public static string GetHeaderTextMember(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderTextMemberProperty);
        }
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        public static void SetHeaderTextMember(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderTextMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetWidthMember(DependencyObject obj)
        {
            return (string)obj.GetValue(WidthMemberProperty);
        }
        public static void SetWidthMember(DependencyObject obj, string value)
        {
            obj.SetValue(WidthMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetSortMember(DependencyObject obj)
        {
            return (string)obj.GetValue(SortMemberProperty);
        }
        public static void SetSortMember(DependencyObject obj, string value)
        {
            obj.SetValue(SortMemberProperty, value);
        }
        private static void ColumnsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).ColumnsSource = e.NewValue;
        }
        private static void DisplayMemberFormatMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).DisplayMemberFormatMember = e.NewValue as string;
        }
        private static void DisplayMemberMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).DisplayMemberMember = e.NewValue as string;
        }
        private static void FontWeightBindingMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).FontWeightBindingMember = e.NewValue as string;
        }
        private static void FontWeightMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).FontWeightMember = e.NewValue as string;
        }
        private static void IsEditableMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).IsEditableMember = e.NewValue as string;
        }
        private static void HeaderTextMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).HeaderTextMember = e.NewValue as string;
        }
        private static void SortMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).SortMember = e.NewValue as string;
        }
        private static void TextAlignmentMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).TextAlignmentMember = e.NewValue as string;
        }
        private static void TextColourMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).TextColourMember = e.NewValue as string;
        }
        private static void WidthMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridColumnCollection.GetOrCreateBehaviour(sender).WidthMember = e.NewValue as string;
        }
        private static DataGridColumnCollectionBehaviour GetOrCreateBehaviour(DependencyObject source)
        {
            DataGridColumnCollectionBehaviour behaviour = DataGridColumnCollection.GetColumnCollectionBehaviour(source);
            if (behaviour == null)
            {
                behaviour = new DataGridColumnCollectionBehaviour(source as DataGrid);
                DataGridColumnCollection.SetColumnCollectionBehaviour(source, behaviour);
            }
            return behaviour;
        }
    }
