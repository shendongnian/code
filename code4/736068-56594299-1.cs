public ObservableCollection<RowViewModel> Rows { get; set; }
The method below has two key advantages:
* It's designed to work efficiently with the WPF runtime to minimise on-screen rendering using bulk updates.
* So it's fast.
* And because the boilerplate code is listed below, it's easier to follow compared to any other docs you will find on the web.
Please let me know if this worked for you, any issues and I'll update the instructions to make easier.
And the steps:
### Step 1: Non-notifying Collection Wrapper
Create a special ObservableCollection that does not fire update events. This is a one-off. We want to fire the update bulk update event ourselves, which is faster.
public class NonNotifyingObservableCollection<T> : ObservableCollection<T>
{
    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e) { /* Do nothing */ }
}
### Step 2: Convert to NonNotifyingObservableCollection
Convert to a private variable which uses this new collection.
private NonNotifyingObservableCollection<RowViewModel> rows;
// ... and in constructor
rows = new NonNotifyingObservableCollection<RowViewModel>();
### Step 3: Add Wrapper
Add these variables:
private ICollectionView rowsView;
public ICollectionViewLiveShaping RowsLiveView { get; set; }
And in the Initialise() call after the ViewModel is constructed (or perhaps in the constructor):
// Call on the dispatcher.
dispatcher.InvokeAsync(() =>
{
    this.rowsView = CollectionViewSource.GetDefaultView(this.rows);
    this.rowsView.Filter = o =>
        {
            // This condition must be true for the row to be visible on the grid.
            return ((RowViewModel)o).IsVisible == true;
        };
    this.RowsLiveView = (ICollectionViewLiveShaping)this.rowsView;
    this.RowsLiveView.IsLiveFiltering = true;
    // For completeness. Changing these properties fires a change notification (although
    // we bypass this and manually call a bulk update using Refresh() for speed).
    this.RowsLiveView.LiveFilteringProperties.Add("IsVisible");
});
### Step 4: Add items
Now we add items to the backing collection, then call `.Refresh()` to refresh the view:
this.rowsView.Add(new RowViewModel( /* Set properties here. */ ));
We then bind the grid to `RowsLiveView`, (instead of binding to `Rows` in the original code).
### Step 5: Update live filtering
Now we can update the `IsVisible` property, then call `.Refresh()` to redraw the grid.
rows[0].IsVisible=false;
this.rowsView.Refresh(); // Hides the first row.
