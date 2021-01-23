    [DllImport("winscard.dll"]
    public static extern int SCardGetCardTypeProviderName(
        IntPtr hContext,
        string szCardName, 
        uint dwProviderId, 
        StringBuilder szProvider, 
        ref int pcchProvider
    );
    ....
    StringBuilder providerName = new StringBuilder(providerNameLength);
    int lReturn = SCardGetCardTypeProviderName(
        hSC, 
        cardName, 
        SCARD_PROVIDER_CSP, 
        providerName, 
        ref providerNameLength
    );
