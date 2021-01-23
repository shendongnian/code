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
