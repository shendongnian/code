    public static ChangedEventHandler FilterByDelta(double delta,
                                                    ChangedEventHandler handler)
    {
        double previous = double.MinValue;
        return d =>
        {            
            if (d - previous > delta)
            {
                handler(d);
            }
            // Possibly put this in the "if" block? Depends on what you want.
            previous = d;
        };
    }
