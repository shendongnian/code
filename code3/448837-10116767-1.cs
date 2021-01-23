    void Main()
    {
    	var result = CalculateTax(40000);
    	Console.WriteLine(result);
    }
    
    public int CalculateTax(int income)
    {
        var incLimit = 50000;
    	var lowTaxRate = 0.10;
    	var highTaxRate = 0.25;
    	int taxOwed;
    	if (income < incLimit){
    		taxOwed = Convert.ToInt32(income * lowTaxRate); }
    	else if(income >= incLimit) {
    		taxOwed = Convert.ToInt32(income * highTaxRate);}
    	return taxOwed;
    }
