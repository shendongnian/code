    public void AccessToCsvFileVerificationInputs(bool access)
    {
        view_.EnableSelectCSVFilePath = access;
        view_.NumberOfColumns.Enabled = access;
        view_.CurrencyPair = access;
        // And so on...
    }
 
