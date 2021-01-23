    public Model SomeModel
    {
        get
        {
            return Model;
        }
        set
        {
            if (Model == value)
                return;
            else
            {
                Model= value;
                base.OnPropertyChanged("SomeModel");
            }
        }
    }
