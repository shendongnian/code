    class People
    {
    private decimal cash;
    private string name = "";
    public string Name
    {
    get { return name; }
    set { name = value; }
    }
    public decimal Cash
    {
    get { return cash; }
    set { cash = value; }
    }
    
    public static void Give(People p1,People p2, decimal amount)
    {
      p2.Cash -= amount;
      p1.Cash += amount;
    }
    }
