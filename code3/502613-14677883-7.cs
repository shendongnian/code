    public void Proc(object parameter)
    {
        new { parameter }.ThrowIfNull(); //you have to call it this way.
    
        // Main code.
    }
