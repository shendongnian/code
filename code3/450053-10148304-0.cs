        public static void PushToggleButton(ToggleButton b)
        {
            ToggleButtonAutomationPeer peer = new ToggleButtonAutomationPeer(b);
            System.Windows.Automation.Provider.IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as System.Windows.Automation.Provider.IInvokeProvider;
            invokeProv.Invoke();
        }
