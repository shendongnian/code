    private string _noteTitle = string.Empty; 
    public string NoteTitle 
    { 
        get { return this._noteTitle; } 
        set 
        { 
            this._noteTitle = value; // set the field value
            RaisePropertyChanged("NoteTitle"); 
        } 
    }
