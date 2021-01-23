    //Option 1.ViewModel act as DTO / expose some Model's property and responsible for UI logic.
    public string Title
    {
        get 
        {
            // some getter logic
            return string.Format("{0}", this.model.Title); 
        }
        set
        {
            // if(Validate(value)) add some setter logic
            this.model.Title = value;
            RaisePropertyChanged(() => Title);
        }
    }
    //Option 2.expose the Model (have self validation and implement INotifyPropertyChanged).
    public IModel Model
    {
        get { return this.model; }
        set
        {
            this.model = value;
            RaisePropertyChanged(() => Model);
        }
    }
