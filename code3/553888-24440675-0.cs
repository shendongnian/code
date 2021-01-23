    double[] MovingAverage(int period, double[] source)
    {
        var ma = new double[source.Length];
        
        double sum = 0;
        for (int bar = 0; bar < period; bar++)
            sum += source[bar];
            
        for (int bar = period; bar < source.Length; bar++)
            ma[bar] = ma[bar - 1] + source[bar]/period
                                  - source[bar - period]/period;
                                
        return ma;
    }
