    private EmployeeListViewModel()
        : base("")
    {
        EmployeeList = new ObservableCollection<EmployeeViewModel>(GetEmployees());
        this._view = new ListCollectionView(this.employeeList);
		 myEmployeeList = new CollectionViewSource();
            myEmployeeList.Source = this.EscortList;
            myEmployeeList.Filter += ApplyFilter;
    }
        internal CollectionViewSource employeeList { get; set; }
	        internal CollectionViewSource myEmployeeList { get; set; }
			private ObservableCollection<EmployeeViewModel> employeeList;
        public ObservableCollection<EmployeeViewModel> EmployeeList
        {
            get { return employeeList; }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }
    private ListCollectionView _view;
	// the collection below is the collection you will need to be your listview itemsource {Binding View}
    public ICollectionView View
    {
         //you need to return your CollectionViewSource here
		 get { return myEmployeeList._view; }
    }
	
	// you need to use the following filtering methods as it did work for methods
	 private void OnFilterChanged()
        {
            myEmployeeList.View.Refresh();
        }
        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set
            {
                this.filter = value;
                OnFilterChanged();
            }
        }
        void ApplyFilter(object sender, FilterEventArgs e)
        {
            EmployeeViewModel svm = (EmployeeViewModel)e.Item;
            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
            {
                e.Accepted = true;
            }
            else
            {
			// you can change the property you want to search your model
                e.Accepted = svm.Surname.Contains(Filter);
            }
        }
