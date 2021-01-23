    object parameter = new object();
    
    FailedChangeRef(parameter); // parameter still points to the same object
    ChangeRef(ref parameter); // parameter now points to null
    
    public void FailedChangeRef(object parameter)
    {
                parameter = null; // this has no effect on the calling variable
    }
    
    public void ChangeRef(ref object parameter)
    {
                parameter = null;  
    }
