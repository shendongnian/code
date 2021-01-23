    private string mask1;
    public string Mask1
    {
        get { return mask1; }
        set 
            { 
               mask2 = value;
               RaisePropertyChanged("Mask1");
            }
    }
