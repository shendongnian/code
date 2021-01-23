    public class MyListView : ListView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MyListViewItem();
        }
    }
    public class MyListViewItem : ListViewItem
    {
        protected override void OnRightTapped(Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            base.OnRightTapped(e);
            e.Handled = false; // Stop 'swallowing' the event
        }
    }
    <CustomControls:MyListView
		x:Name="MyListView"
		...
		SelectionMode="Single"
		RightTapped="MyListView_RightTapped">
    </CustomControls:MyListView>
