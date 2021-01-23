    public decimal ToMoney(double Input) {
        int _precision = 2;
        decimal _result;
        try{
            double multiplier = Math.Pow(10, Convert.ToDouble(_precision));
            _result = System.Convert.ToDouble(Math.Ceiling(input * multiplier) / multiplier);
        } catch {}
        return _result;
    }
