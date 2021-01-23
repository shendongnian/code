    public Jurisdiction CountryResidence
    {
        get
        {
            return Model.CountryResidence;
        }
        set
        {
            if (Model.CountryResidence != value)
            {
                Model.CountryResidence = value;
                base.OnPropertyChanged("CountryResidence");
            }
        }
    }
