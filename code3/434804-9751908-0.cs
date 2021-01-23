    public double[] TotalPurchasesLastThreeDays
    {
        get {
            return totalPurchasesLastThreeDays;
        }
        set {
            totalPurchasesLastThreeDays = (double[])value.Clone();
        }
    }
