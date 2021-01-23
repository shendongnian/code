    private double Price;
    private bool Food;
    private int count;
    private decimal finalprice;
    
    public void Readinput()
    {
    	Console.Write("Unit price:  ");
    	double.TryParse(Console.ReadLine(), out Price);
    
    	Console.Write("Food item y/n:  ");
    	bool.TryParse(Console.ReadLine(), out Food);
    
    	Console.Write("Count:  ");
    	int.TryParse(Console.ReadLine(), out count);
    }
    
    private void calculateValues()
    {
    	finalprice = Price * count;
    }
