    public class MultipleSelectionListBox : ListBox
    {
        public static readonly DependencyProperty BindableSelectedItemsProperty =
            DependencyProperty.Register("BindableSelectedItems",
                typeof(IEnumerable<string>), typeof(MultipleSelectionListBox),
                new FrameworkPropertyMetadata(default(IEnumerable<string>),
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnBindableSelectedItemsChanged));
        public IEnumerable<string> BindableSelectedItems
        {
            get => (IEnumerable<string>)GetValue(BindableSelectedItemsProperty);
            set => SetValue(BindableSelectedItemsProperty, value);
        }
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            BindableSelectedItems = SelectedItems.Cast<string>();
        }
        private static void OnBindableSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MultipleSelectionListBox listBox)
                listBox.SetSelectedItems(listBox.BindableSelectedItems);
        }
    }
