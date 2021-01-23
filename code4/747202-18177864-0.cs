    private ObservableCollection<Dinosaur> _dinoList = new ObservableCollection<Dinosaur>();
    public ObservableCollection<Dinosaur> Dinosaurs
    {
       get { return _dinoList; }
       set { _dinoList = value; RaisePropertyChanged("Dinosaurs"); }
    }
