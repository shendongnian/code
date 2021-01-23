    private Note selectedDetailNote;
    public Note SelectedDetailNote
    {
        get { return this.selectedDetailNote; }
        set 
        { 
            this.selectedDetailNote = value; 
            this.NotifyOfPropertyChange(() => this.SelectedDetailNote); 
        }
    }
