    void CalculateT0(DateTime calculationBase) {...}
    void CalculateT1(DateTime calculationBase) {...}
    
    void T0_ButtonClick(...)
    {
        CalculateT0(DateTime.Now);
    }
    
    void T1_ButtonClick(...)
    {
        CalculateT1(DateTime.Now);
    }
    
    void T0Plus1_ButtonClick(...)
    {
        var calculationBase = DateTime.Now;
        CalculateT0(calculationBase);
        CalculateT1(calculationBase);
    }
