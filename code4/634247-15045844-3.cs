    public class BrowseStoreViewModel : DependencyObject {
        // Dependency property for Selected Item
        // Replace "ItemType" with type you're populating GridView
    	public ItemType SelectedItem {
    		get { return (ItemType )GetValue(SelectedItemProperty); }
    		set { SetValue(SelectedItemProperty, value); }
    	}
    	public static readonly DependencyProperty SelectedItemProperty=
    		DependencyProperty.Register("SelectedItem", typeof(ItemType), typeof(BrowseStoreViewModel), new PropertyMetadata(default(ItemType)));
    }
