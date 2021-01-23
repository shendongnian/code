    public class ListBoxCustom : ListBox
    {
        public ListBoxCustom()
        {
            SelectionChanged += ListBoxCustom_SelectionChanged;
        }
        void ListBoxCustom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItemsList = SelectedItems;
        }
        public IList SelectedItemsList
        {
            get { return (IList)GetValue(SelectedItemsListProperty); }
            set { SetValue(SelectedItemsListProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemsListProperty =
           DependencyProperty.Register(nameof(SelectedItemsList)", typeof(IList), typeof(ListBoxCustom), new PropertyMetadata(null));
    }
