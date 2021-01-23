    public int TruncValue
    {
        get 
        { 
            if(Value > (float)int.MaxValue)
            {
                return int.MaxValue
            }    
            else if(Value < (float)int.MinValue)
            {
                return int.MinValue
            }
            else
            {
                return (int)Value; 
            }
        }
    }
