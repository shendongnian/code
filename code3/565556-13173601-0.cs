    public double CalcCouponValue()
    {
        double Rate = 0;
        if (balance < 2500)
        {
            Rate = 0.03 * balance;
        }
        else if ( year < 2)
        {
            Rate = 0.04 * balance;
        }
        else if ( year >= 2)
        {
            Rate = 0.05 * balance;
        }
        return Rate;
    }
