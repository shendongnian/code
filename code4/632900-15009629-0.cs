    public async Task Start()
    {
        // in app purchase setup
        m_HideAdsFeature = await new InAppPurchaseHelper(HIDEADSFAETURENAME,
            System.Diagnostics.Debugger.IsAttached).Setup();
        this.HideAds = m_HideAdsFeature.IsPurchased;
    }
    bool m_HideAds = false;
    public bool HideAds { get { return m_HideAds; } set { SetProperty(ref m_HideAds, value); } }
    const string HIDEADSFAETURENAME = "HideAds";
    InAppPurchaseHelper m_HideAdsFeature;
    // http://codepaste.net/ho9s5a
    DelegateCommand m_PurchaseHideAdsCommand = null;
    public DelegateCommand PurchaseHideAdsCommand
    {
        get
        {
            if (m_PurchaseHideAdsCommand != null)
                return m_PurchaseHideAdsCommand;
            m_PurchaseHideAdsCommand = new DelegateCommand(
                PurchaseHideAdsCommandExecute, PurchaseHideAdsCommandCanExecute);
            this.PropertyChanged += (s, e) => m_PurchaseHideAdsCommand.RaiseCanExecuteChanged();
            return m_PurchaseHideAdsCommand;
        }
    }
    async void PurchaseHideAdsCommandExecute()
    {
        PauseCommandExecute();
        await m_HideAdsFeature.Purchase();
        HideAds = m_HideAdsFeature.IsPurchased;
    }
    bool PurchaseHideAdsCommandCanExecute()
    {
        if (m_HideAdsFeature == null)
            return false;
        return !m_HideAdsFeature.IsPurchased;
    }
