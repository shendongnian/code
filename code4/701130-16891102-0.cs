    public void PID(decimal _actualSpeed, Decimal _speedRequest, out Decimal _pwmAuto, out decimal _preValReg)
    {
        _pwmAuto = valReg;
        _preValReg = valReg - 1;
        _timer = new System.Timers.Timer();
        _timer.Interval = (3000);
        _timer.Elapsed += (sender, e) => { HandleTimerElapsed(_actualSpeed, _speedRequst, _pwmAuto, _preValReg); };        
        _timer.Enabled = true;
        // {....}
    }
    static void HandleTimerElapsed(Decimal actualSpeed, Decimal speedRequst, Decimal pwmAuto, Decimal preValReg)
    {
       // (...)
    }
