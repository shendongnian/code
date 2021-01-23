    EnumerableDataSource<Point> m_d3DataSource;
    public EnumerableDataSource<Point> D3DataSource {
        get {
            return m_d3DataSource;
        }
        set {                
            //you can set your mapping inside the set block as well             
            m_d3DataSource = value;
            OnPropertyChanged("D3DataSource");
        }
    }     
    
    protected void OnPropertyChanged(PropertyChangedEventArgs e) {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null) {
            handler(this, e);
        }
    } 
    
    protected void OnPropertyChanged(string propertyName) {
        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    } 
