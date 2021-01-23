    public class MainViewModel {
      ItemViewModel selectedItem1;
      public MainViewModel(IEnumerable<ItemViewModel> items1) {
        Items1 = items1;
        Items2 = new ObservableCollection<ItemViewModel>();
      }
      public IEnumerable<ItemViewModel> Items1 { get; private set; }
      public ObservableCollection<ItemViewModel> Items2 { get; private set; }
      public ItemViewModel SelectedItem1 {
        get { return this.selectedItem1; }
        set {
          this.selectedItem1 = value;
          if (this.selectedItem1 != null && !Items2.Contains(this.selectedItem1))
            Items2.Add(this.selectedItem1);
        }
      }
    }
