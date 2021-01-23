    private bool endDateEnabled = false;
    public bool EndDateEnabled 
    {
        get { return endDateEnabled; }
        set 
        {
            if (endDateEnabled != value)
            {
                endDateEnabled = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("EndDateEnabled"));
            }
        }
    }
