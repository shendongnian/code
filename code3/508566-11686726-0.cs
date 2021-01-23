       public frmLoad()
        {
          
            InitializeComponent();
            string DisplayQuery = "Select * from TableName";
             MasterDs = SqlHelper.ExecuteDataset(CommonClass.ConnectionString, CommandType.Text, DisplayQuery);
            MasterDs.Tables[0].Columns.Add("FLAG", typeof(string));
            MainGrid.DataSource = MasterDs.Tables[0];
            gridview.PopulateColumns();
            gridview.Columns["ID"].VisibleIndex = -1;
            gridview.Columns["FLAG"].VisibleIndex = -1;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit selectnew = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            gridview.Columns["ColName"].ColumnEdit = selectnew;
            selectnew.NullText = "";
            selectnew.ValueChecked = "Y";
            selectnew.ValueUnchecked = "N";
            selectnew.ValueGrayed = "-";
        
        }
