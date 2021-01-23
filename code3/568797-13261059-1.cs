    public static Money operator +(Money x, Money y)
    {
       var totalCents = x.Cents + y.Cents;
       var retCents = totalCents / 100;
       var retDollars = x.Dollars + y.Dollars + (totalCents % 100)
       return new Money(retDollars, retCents);
    }
