    public class MasterDataGridView: System.Windows.Forms.DataGridView
    {
        public MasterDataGridView()
        {
            BackColor = Color.Yellow;
            // define other behaviours
        }
    }
    
    public class OrdersDataGridView : MasterDataGridView
    {
       // data binding, column addition etc can be handle in respective grid views
    }
    public class ReportsDataGridView : MasterDataGridView
    {
    }
