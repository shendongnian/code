    //ItemsSource - pData
    //There is a string attribute - wTitle included in the fooClass (DisplayMemberPath)
    private ObservableCollection<fooClass> __pData;
    public ObservableCollection<fooClass> pData {
        get { return __pData; }
        set { Set(() => pData, ref __pData, value);
            RaisePropertyChanged("pData");
        }
    }
    
    private string _SearchText;
    public string SearchText {
        get { return this._SearchText; }
        set {
            this._SearchText = value;
            RaisePropertyChanged("SearchText");
            
            //Update your ItemsSource here with Linq
            pData = new ObservableCollection<fooClass>{pData.ToList().Where(.....)};
        }
    }
