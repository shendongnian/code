    private ObservableCollection<WritableKeyValuePair<int, string>> _traceDisplayList = null;
    private WritableKeyValuePair<int, string> _selectedTraceType = new WritableKeyValuePair<int, string>();
                
   
    public OptionsFilterViewModel()
    {
           _traceDisplayList = new ObservableCollection<WritableKeyValuePair<int, string>>();
           _traceDisplayList.Add(new WritableKeyValuePair<int, string>((int)TraceDisplayEnum.All, ProjectResources.All));
           _traceDisplayList.Add(new WritableKeyValuePair<int, string>((int)TraceDisplayEnum.WithEx, ProjectResources.TraceException));
           _traceDisplayList.Add(new WritableKeyValuePair<int, string>((int)TraceDisplayEnum.ExOnly, ProjectResources.ExceptionOnly));
    }
        
        /// <summary>
            /// Listes des types de traces
            /// </summary>
            public ObservableCollection<WritableKeyValuePair<int, string>> TraceDisplayList
            {
              get { return _traceDisplayList; }
              set
              {
                _traceDisplayList = value;
                RaisePropertyChanged<OptionsFilterViewModel>(x => x.TraceDisplayList);
              }
            }
        
            /// <summary>
            /// Type de trace sélectionné dans la liste
            /// </summary>
            public WritableKeyValuePair<int, string> SelectedTraceType
            {
              get
              {
                return _selectedTraceType;
              }
              set
              {
                _selectedTraceType = value;
                RaisePropertyChanged<OptionsFilterViewModel>(x => x.SelectedTraceType);
              }
        
            }
