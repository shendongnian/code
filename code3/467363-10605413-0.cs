    public class LcViewModel : BaseItemsViewModel
    {
        public LcViewModel()
        {
            MoveCommand = new RelayCommand(Move);
            var view = CollectionViewSource.GetDefaultView(Items);
            view.CurrentChanged += (sender, args) => Debug.WriteLine("CurrentChanged");
            view.CurrentChanging += (sender, args) => Debug.WriteLine("CurrentChanging");
        }
        public ICommand MoveCommand { get; private set; }
        private void Move()
        {
            var view = CollectionViewSource.GetDefaultView(Items);
            view.MoveCurrentToFirst();
        }
    }
