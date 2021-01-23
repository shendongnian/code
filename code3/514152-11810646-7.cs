    public void AccessToCsvFileVerificationInputs(bool access)
    {
        view_.EnableSelectCSVFilePath = access;
        view_.EnableNumberOfColumns = access;
        view_.EnableCurrencyPair = access;
        // And so on...
    }
 
