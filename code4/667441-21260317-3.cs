    public string GetAgeText(DateTime birthDate)
    {
            const double ApproxDaysPerMonth = 30.4375;
            const double ApproxDaysPerYear = 365.25;
            /*
               The above are the average days per month/year over a normal 4 year period. 
               We use these approximations because they are more accurate for the next century or so.  
               After that you may want to switch over to these 400 year approximations... 
              
               ApproxDaysPerMonth = 30.436875
               ApproxDaysPerYear  = 365.2425 
              How to get theese numbers:
                The are 365 days in a year, unless it is a leepyear.
                Leepyear is every forth year if Year % 4 = 0
                unless year % 100 == 1
                unless if year % 400 == 0 then it is a leep year.
                This gives us 97 leep years in 400 years. 
                So 400 * 365 + 97 = 146097 days.
                146097 / 400      = 365.2425
                146097 / 400 / 12 = 30,436875
              
                Due to the nature of the leepyear calculation, on this side of the year 2100
                you can assume every 4th year is a leepyear and use the other approximatiotions. 
  
            */
        //Calculate the span in days
        int iDays = (DateTime.Now - birthDate).Days;
    
        //Calculate years as an integer division
        int iYear = (int)(iDays / ApproxDaysPerYear);
    
        //Decrease remaing days
        iDays -= (int)(iYear * ApproxDaysPerYear);
        //Calculate months as an integer division
        int iMonths = (int)(iDays / ApproxDaysPerMonth);
        //Decrease remaing days
        iDays -= (int)(iMonths * ApproxDaysPerMonth);
        //Return the result as an string   
        return string.Format("{0} years, {1} months, {2} days", iYear, iMonths, iDays);
    }
