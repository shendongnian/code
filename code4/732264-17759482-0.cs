    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = clsTransaction.Select(@"SELECT TOP 10000 A.reid AS [ID],
    A.nm AS [Name],
    B.nm AS [Server],
    CASE WHEN D.nm IS NULL THEN A.nm ELSE D.nm END as [Parent],
    CASE WHEN C.nm IS NULL THEN A.nm ELSE C.nm END as [Top Perent],
    CASE WHEN A.isparent = 1 THEN 'Not a group reseller' ELSE 'Group reseller' END AS [Is     Group] 
    FROM tblReseller AS A
    LEFT OUTER JOIN tblwser B on (A.wsid = B.wsid)
    LEFT OUTER JOIN tblReseller AS C ON (A.tparentid = C.acid AND A.wsid = C.wsid)
    LEFT OUTER JOIN tblReseller AS D ON (A.parentid = D.acid AND A.wsid = D.wsid)",     DataSendBSSWEB.ServerDbEnum.MainSqlServer, false);
        #region Table fill
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        foreach (DataColumn dc in ds.Tables[0].Columns)
        {
            tc = new TableCell();
            tc.Text = dc.ColumnName;
            tr.Cells.Add(tc);
        }
        tblview.Rows.Add(tr);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            tr = new TableRow();
            foreach (object obj in dr.ItemArray)
            {
                tc = new TableCell();
                tc.Text = obj.ToString();
                tr.Cells.Add(tc);
            }
            tblview.Rows.Add(tr);
        }
        #endregion
    if (!Page.IsPostBack)
    {
       
        #region Grid Fill
        grvView.DataSource = ds.Tables[0];
        grvView.DataBind();
        grvView.EnableViewState = true;
        #endregion
    }
    }
