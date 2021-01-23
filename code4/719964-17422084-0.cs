                private ObservableCollection<AttractionDetails> _attractionlist;
                public ObservableCollection<AttractionDetails> attractionlist
                {
                    get
                    {
                        return _attractionlist;
                    }
                    set
                    {
                        _attractionlist = value;
                        RaisePropertyChanged("attractionlist");
    
                       // Change visibility here
                    }
                }
