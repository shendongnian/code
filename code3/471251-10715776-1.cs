    long xi;
    if (long.TryParse(numberString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowLeadingSign, null, out xi))
        {
            // OK, use xi
        }
        else
        {
            // not valid string, xi is 0
        }
     
