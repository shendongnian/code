    double num = roundPower10Double[digits];
    value *= num;
    if (mode == MidpointRounding.AwayFromZero)
    {
        double num2 = SplitFractionDouble(&value);
        if (Abs(num2) >= 0.5)
        {
            value += Sign(num2);
        }
    }
