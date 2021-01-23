    public class MyViewModel : ViewModelBase
    {
        private void RefreshItems()
        {
            RaisePropertyChanged("Items");
        }
        private ObservableCollection<DataItem> Items { ... }
    }
