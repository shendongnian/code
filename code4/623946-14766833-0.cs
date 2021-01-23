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
    
    public void Give(Person target, decimal amount)
    {
      Cash -= amount;
      target.Cash += amount;
    }
    }
