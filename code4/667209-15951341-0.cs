    class BrowserViewModel
    {
        #region Properties
        public ObservableCollection<TreeViewModel> Status { get; private set; }
        public string Conditions { get; private set; }
 
        #endregion // Properties
        // i'd like to call this method when Status gets updated
        void updateConditions
        {
             /* Conditions = something */
        }
        public BrowserViewModel()
        {
            Status = new ObservableCollection<TreeViewModel>();
            Status.CollectionChanged += (e, v) => updateConditions();
        }
    }
