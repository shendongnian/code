    // Property for toggle button GUI update
    public bool IsRecording{
    get{ return _isRecording;}
    set{
        _isRecording = value;
        NotifyPropertyChanged("IsRecording");
        }
    }
    
    public ICommand ToggleRecordCommand{
    // Your command logic.
    }
