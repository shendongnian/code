    Regex R = new Regex("(?i)(discardnew|discardold)");
    bool i1 = R.IsMatch("DiscardOld");
    bool i2 = R.IsMatch("discardOld");
    bool i3 = R.IsMatch("discardOLD");
    bool i4 = R.IsMatch("discardneW");
    bool i5 = R.IsMatch("Discardnew");
    bool i6 = R.IsMatch("dISCARDnew");
