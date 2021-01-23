    public override void GiveBonus(float amount)
    {
        base.GiveBonus(amount);
        Random r = new Random();
        // Note numberOfOpts, not currPay
        numberOfOpts += r.Next(500);
    }
