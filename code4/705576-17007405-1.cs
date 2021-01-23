    class ViewModel {
      public ViewModel() {
        Items = new ObservableCollection<String>();
      }
      public ObservableCollection<String> Items { get; private set; }
    }
