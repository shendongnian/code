    // Set the column width
    public void SetColWdth(string rng, double wdth)
    {
        Range = excelSheet.GetType().InvokeMember("Range",
        BindingFlags.GetProperty,null, excelSheet, new object [] {rng});
        object [] args = new object [] {wdth};
        Range. GetType().InvokeMember ("Columnwdth",
        BindingFlags.SetProperty, null, Range, args);
    }
