    public class CustomListBoxItem : ListBoxItem
    {
        public static readonly DependencyProperty IsVirtuallySelectedProperty =
           DependencyProperty.Register("IsVirtuallySelected", typeof(bool), 
                                       typeof(CustomListBoxItem),
                                       new PropertyMetadata(false));
        public CustomListBoxItem() : base()
        { }
        public bool IsVirtuallySelected
        {
            get { return (bool)GetValue(IsVirtuallySelectedProperty); }
            set { SetValue(IsVirtuallySelectedProperty, value); }
        }
    }
