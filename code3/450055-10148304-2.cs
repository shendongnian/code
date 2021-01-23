    public static void PushToggleButton(ToggleButton b)
    {
        ToggleButtonAutomationPeer peer = new ToggleButtonAutomationPeer(b);
        System.Windows.Automation.Provider.IToggleProvider toggleProvider = peer.GetPattern(PatternInterface.Toggle) as System.Windows.Automation.Provider.IToggleProvider;
        toggleProvider.Toggle();
    }
