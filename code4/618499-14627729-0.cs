    public double GetBonusRate(int workingDays, int numberOfSales)
    {
        if(numberOfSales > 20)
        {
          return 1.5;
        }
    	
        if(workingDays >= 20 && numberOfSales > 10)
        {
          return 1.2;
        }
    	
        if(numberOfSales > 5)
        {
          return 1.0;
        }
    	
        if(workingDays > 10)
        {
          return 0.1;
        }
    	
        return 0;
    }
