    DateTime dob = .....
    DateTime Today = DateTime.Now;
    TimeSpan ts = Today - dob;
    DateTime Age = DateTime.MinValue + ts;
    
    
    // note: MinValue is 1/1/1 so we have to subtract...
    int Years = Age.Year - 1;
    int Months = Age.Month - 1;
    int Days = Age.Day - 1;
