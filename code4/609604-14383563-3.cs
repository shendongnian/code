    // Should have first monday now.
    // Loop until the month changes
    while ( testDate.Month == month)
    {
       var monday = testDate;
       var friday = testDate.AddDays(4);
    
       // You now have both dates.  Do whatever you need to.
       // here.
       
       // Increment test date by a week
       testDate = testDate.AddDays(7)
    }
