    public class MainWindowViewModel
    {
        #region Constructor
        public MainWindowViewModel()
        {
            YourGridList = new ObservableCollection<GridElement>();
            var el = new GridElement
                         {
                             Element1 = "element 1", 
                             Element2 = "element 2", 
                             Element3 = "element 3"
                         };
            YourGridList.Add(el);
        }
        #endregion
        #region Private members
        
        private ObservableCollection<GridElement> _yourGridList;
        private ICommand _addElementCommand;
        
        #endregion
        #region Public properties
        public ObservableCollection<GridElement> YourGridList
        {
            get
            {
                return _yourGridList;
            }
            set
            {
                _yourGridList = value;
            }
        }
        #endregion
        #region Commands
        public ICommand AddElementCommand
        {
            get { return _addElementCommand ?? (_addElementCommand = new DelegateCommand(AddElement)); }
        }
        #endregion
        #region Private Methods
        private void AddElement()
        {
            var el = new GridElement
            {
                Element1 = "NewEl1",
                Element2 = "NewEl2",
                Element3 = "NewEl3"
            };
            YourGridList.Add(el);
        }
        #endregion
