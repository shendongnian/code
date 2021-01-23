    private object _selecteditem;
    public object SelectedItem
    {
        get { return _selecteditem; }
        set
        {
            OCContext = new ObservableCollection<T_Wertung>();
            if (value is T_Frage)
            {
                T_Frage selected = (T_Frage)value;
		//do something with selected
		OCContext.Add(new T_Wertung(1,"Test",100));
                }
            }
            RaisePropertyChanged(() => SelectedItem);
        }
    }
    private ObservableCollection<T_Wertung> _occontext;
    public ObservableCollection<T_Wertung> OCContext
    {
        get
        {
            if (_occontext == null)
                _occontext = new ObservableCollection<T_Wertung>();
            return _occontext;
        }
        set
        {
            _occontext = value;
            RaisePropertyChanged(() => OCContext);
        }
    }
