        private void GenerateCoaTree()
        {
            DataSet ds = new DataSet();
            dcAccountingDataContext dc = new dcAccountingDataContext();
            DataTable dt = dc.usp_RPT_ChartOfAccount_Select(null, CompanyID).CopyToDataTable();
            ds.Tables.Add(dt);
           // The second parmeter for the ID of the element and the third parameter is the ID of the parent element in the tree.
            TreeViewCoa.DataSource = new HierarchicalDataSet(ds, "AccountID", "COA_ID");
            TreeViewCoa.DataBind();
        }
