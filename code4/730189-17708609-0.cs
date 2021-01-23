    public static implicit operator Money(Double value)
    {
        var money = new Money();
        money.Raw = value;
        return money;
    }
