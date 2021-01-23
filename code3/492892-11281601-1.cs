    private string first;
    public string First
    {
        get { return first; }
        set
        {
            first = value;
            var handler = PropertyChanged; //according to Essential C# (M. Michaelis) 
            if (handler != null)           //the copy should prevent threading issues
            {                              //but that's a disputed subject
                handler(this, new PropertyChangedEventArgs("First"));
            }
        }
    }
