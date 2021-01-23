    AutomationPeer myDataGridAutomationPeer = null;
    public MyDataGrid()
    {
        Loaded += MyDataGrid_Loaded;
    }
    void MyDataGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        myDataGridAutomationPeer = UIElementAutomationPeer.CreatePeerForElement(this);
    }
    protected override System.Windows.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
    {
        return myDataGridAutomationPeer;
    }
