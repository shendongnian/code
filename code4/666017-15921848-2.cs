    ObservableList<String> featList = new ObservableCollection<String>();
    public event PropertyChangedEventHandler PropertyChanged;
    public void InvokePropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
    public ObservableList<String> FeatList
    {
        get { return featList; }
        set
        {
            featList = value;
            InvokePropertyChanged("FeatList");
        }
    }
    List<Feature> features = App.dResult.directions[0].features;
    foreach (Feature f in features)
    {
        Attributes a = f.attributes;
        //MessageBox.Show(a.text);
        FeatList.add(a.text);
    }
