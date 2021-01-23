    public partial class MyDataGrid : DataGrid
    {
        protected override System.Windows.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
        {
            return null;
        }
    }
