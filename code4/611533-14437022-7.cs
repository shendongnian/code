    public partial class GridCustomSortTest : Form
    {
        public GridCustomSortTest()
        {
            InitializeComponent();
        }
    
        private void GridCustomSortTest_Load(object sender, EventArgs e)
        {
            string[] months = new string[] { "January", "February", "March", 
                "April", "May", "June", "July", "August", "September", 
                "October", "November", "December" };
    
            grid.DataSource = months;
            grid.RefreshDataSource();
            gridView1.Columns[0].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            gridView1.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(gridView1_CustomColumnSort);
            
            
        }
    
        void gridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            e.Result = Comparer<int>.Default.Compare(e.ListSourceRowIndex1,
               e.ListSourceRowIndex2);
    
            e.Handled = true;
        }
    }
