    public int MyProp 
    {
        get { return _my_prop;}
        private set {
            if value > 10 {
                _my_prop = 10;
            }
        }
    }
