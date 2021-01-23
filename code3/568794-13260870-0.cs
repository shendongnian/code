    public void IncrementMoney(Money x)
    {
        this.Dollars += x.Dollars;
        var newCents = this.Cents + x.Cents;
        this.Cents = newCents % 100;
        
        this.Dollars += newCents / 100;
    }
