    // base class
    public virtual BuyFood()
    {
        BuyPizza();
        BuyCoke();
    }
    private void BuyPizza()
    {
        // ...
    }
    // derived class
    public override void BuyFood()
    {
        BuyChopSuey();
    }
    private void BuyChopSuey()
    {
        // ...
    }
