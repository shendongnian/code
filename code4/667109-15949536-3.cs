    public float Value
    {
        get 
        { 
            var result = ((double)baseValue + (double)baseAdjustment) * (double)baseMultiplier; 
            if(result > (double)int.MaxValue)
            {
               return (float)int.MaxValue)
            }
            if(result < (double)int.MinValue)
            { 
               return (float)int.MinValue)
            }
            return (float)result;
        }
    }
