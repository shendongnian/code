    DateTime? myDate;
    if (myDate != null)
    {
        String runDate = DateTime.Now.ToString();
    }
    else
    {
        DateTime runDate = DateTime.Now.AddDays(1);
    }
    
    string foo = runDate.ToString();
