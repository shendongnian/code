    public Int32 Number { get {
    
                if (Y == 0)
                {
                    return _Size - 1 - X;
                }
                else
                {
                    return _Size + X;
                }
            
            } }
