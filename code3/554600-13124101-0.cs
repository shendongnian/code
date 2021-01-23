    public class MainViewModel {
      readonly ObservableCollection<ItemViewModel> selectedItems
        = new ObservableCollection<ItemViewModel>();
      ItemViewModel selectedItem;
      public MainViewModel(IEnumerable<ItemViewModel> items) {
        Items = items;
      }
      public IEnumerable<ItemViewModel> Items { get; private set; }
      public ItemViewModel SelectedItem {
        get { return this.selectedItem; }
        set {
          this.selectedItem = value;
          if (this.selectedItem != null && !this.selectedItems.Contains(this.selectedItem))
            this.selectedItems.Add(this.selectedItem);
        }
      }
      public ObservableCollection<ItemViewModel> SelectedItems {
        get { return this.selectedItems; }
      }
    }
