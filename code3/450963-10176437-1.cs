    public Jurisdiction CountryResidence
    {
        get { return Model.CountryResidence; }
        set 
        {         
            if (Model.CountryResidence == value)
                return;
            Model.CountryResidence = value;
            OnPropertyChanged(() => CountryResidence);
        }
    }
