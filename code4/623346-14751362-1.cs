    System.Data.DataTable dt = null;
        private void GetData()
        {
            System.Data.DataTable dtMain = // MyDAta Table;
            dt = new System.Data.DataTable();
            dt.Columns.Add("COL_NAME");
            System.Data.DataRow dr = null;
            for (int i = 0; i < dtMain.Columns.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = dtMain.Columns[0].ColumnName;
                dt.Rows.Add(dr);
            }
            rptrTester.DataSource = dtMain;
            rptrTester.DataBind();
        }
        protected void rptrTester_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rptrTesterInner = (Repeater)e.Item.FindControl("rptrTesterInner");
            rptrTesterInner.DataSource = dt;
            rptrTesterInner.DataBind();
        }
