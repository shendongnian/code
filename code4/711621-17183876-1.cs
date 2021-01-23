    public MyClass(){
        _masterWorkerList = new ObservableCollection<Worker>();
        _masterWorkerList.CollectionChanged += OnCollectionChanged;
    }
    public ObservableCollection<Worker> MasterWorkerList
    {
        get { return _masterWorkerList; }
    }
    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e){
        System.Windows.MessageBox.Show("Firing");
        //RaisePropertyChanged(() => MasterWorkerList); 
    }
