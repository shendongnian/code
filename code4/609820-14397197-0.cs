    public partial class TabControlTest : Form
    {
        List<Category> dataSource = new List<Category>();
        public TabControlTest()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                dataSource.Add(new Category { ID = i + 1, Name = "Category" + (i + 1) });
            }
        }
    
        private void TabControlTest_Load(object sender, EventArgs e)
        {
            lookUpEditA.Properties.DataSource = dataSource;
            lookUpEditA.Properties.ValueMember = "ID";
            lookUpEditA.Properties.DisplayMember = "Name";
            lookUpEditA.Properties.PopulateColumns();
            lookUpEditA.Properties.Columns["ID"].Visible = false;
        }
    
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                 lookUpEditB.Properties.DataSource = dataSource;
                lookUpEditB.Properties.ValueMember = "ID";
                lookUpEditB.Properties.DisplayMember = "Name";
                lookUpEditB.Properties.PopulateColumns();
                lookUpEditB.Properties.Columns["ID"].Visible = false;
            }
        }
    }
