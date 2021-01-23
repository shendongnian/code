    public class MyDataGrid : DataGrid
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return null;
        }
    }
