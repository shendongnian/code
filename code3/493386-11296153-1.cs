    double Truncate (double num, int dig)
    {
        if (dig > 15) dig = 15; // Don't overflow
    	long p = Math.Pow (10, dig);
    		
    	// Save the integer part, so that we don't overflow
    	long integer_part = Convert.ToInt64(num);
    	
    	// Fractional part * 10^dig
    	double frac = (num - Convert.ToDouble(integer_part)) * p;
    	long frac_trunc = Convert.ToInt64(frac);
    	
    	// Final result
    	double result = Convert.ToDouble(integer_part) + (Convert.ToDouble(frac_trunc) / p);
    	return result;
    }
