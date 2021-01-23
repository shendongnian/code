    class A : INotifyPropertyChanged
    {
        //So we can let EF know a complex property has changed
        public event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged;
        //here's our actual data, rather than an auto property, we use an explicit member definition so we can call PropertyChanged when Data is changed
        private Dictionary<int, DataType> m_data = new Dictionary<int, DataType>();
        //not mapped property as it's not mapped to a column in EF DB
        [NotMapped()]
        public Dictionary<int, DataType> Data {
            get { return m_data; }
            set {
                m_data = value;
                //now call PropertyChanged for our Front (so EF will know it's been changed)
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("DataAsList"));
                }
            }
        }
        //this is our front for the data, that we use in EF to map data to
        [DebuggerHidden()]
        public ICollection<DataType> DataAsList {
            get {
                ObservableCollection<DataType> ob = new ObservableCollection<DataType>(Data.Values());
                ob.CollectionChanged += Handles_entryListChanged;
                return ob;
            }
            set {
                //clear any existing data, as EF is trying to set the collections value
                Data.Clear();
                //this is how, in my circumstance, i converted my object into the dictionary from an internal obj.Id property'
                foreach (DataType entry in value) {
                    entryions.Add(entry.id, entry);
                }
            }
        }
        //This will now catch wind of any changes EF tries to make to our DataAsList property
        public void Handles_entryListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Debugger.Break()
            switch (e.Action) {
                case NotifyCollectionChangedAction.Add:
                    foreach (DataType entry in e.NewItems) {
                        m_data.Add(entry.Id, entry);
                    }
                    break;
                default:
                    Debugger.Break();
                    break;
            }
        }
    }
