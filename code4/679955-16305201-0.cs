    public override void Debt(double bal)
    {
        if(base.Debt(bal))
            DoSomething();
    }
