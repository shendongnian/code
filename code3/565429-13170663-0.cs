    public bool IsSelected 
    { 
        get{ return _isSelected; }
        set 
        {
            //If two options are true wait for the second change of values
            //You will now only get One notification per change.
            if (twoOptions are selected) return;
            else PropertyChanged.ChangeAndNotify(ref _isSelected, value, () => IsSelected); 
        }
    }
