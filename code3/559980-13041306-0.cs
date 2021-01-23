    public class CustomDataGrid:  DataGrid
    {   
        protected override System.Windows.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
        {
            return null;
        }
    }
