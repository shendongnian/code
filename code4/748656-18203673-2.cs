    public class MyEditorViewModel : ViewModel
    {
        private void SaveChanges()
        {
            var changedItems = Items
                .Where(item => item.HasChanges);
            // send changed items to server
        }
        private bool CanSaveChanges()
        {
            return Items.Any(item => item.HasChanges);
        }
        public MyEditorViewModel()
        {
            SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
        }
        public ObservableCollection<MyListEntryViewModel> Items
        {
            get
            {
                return items ?? (items = new ObservableCollection<MyListEntryViewModel>());
            }
        }
        private ObservableCollection<MyListEntryViewModel> items;
        public RelayCommand SaveChangesCommand { get; private set; }
    }
