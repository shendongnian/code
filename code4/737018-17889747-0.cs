    DateTime? myDate ;
    DateTime runDate ;
    
    if (myDate != null)
    {
        runDate = DateTime.Now;
    }
    else
    {
        runDate = DateTime.Now.AddDays(1);
    }
    
    string foo = runDate.toString();
