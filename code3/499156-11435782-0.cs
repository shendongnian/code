    public class AutocompleteTextBox : TextBox
    {
        public ItemCollection Items
        {
            get {
                return (ItemCollection)GetValue(ItemsProperty); }
            set {
                SetValue(ItemsProperty, value); }
        }
    
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(
                "Items",
                typeof(ItemCollection),
                typeof(AutocompleteTextBox),
                new PropertyMetadata(default(ItemCollection), OnItemsPropertyChanged));
        private static void OnItemsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // AutocompleteTextBox source = d as AutocompleteTextBox;
            // Do something...
        }
