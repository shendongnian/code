            public class MyDataColumn
            {
                public string visibleColumn { get; set; }
                public string hiddenColumn { get; set; }
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    DataTable dataTable = new DataTable();
                    List<MyDataColumn> dataColumns = new List<MyDataColumn>();
    
                    for (int i = 0; i < 10; i++)
                    {
                        dataColumns.Add(new MyDataColumn()
                        {
                            visibleColumn = string.Format("Visible Column {0}", i),
                            hiddenColumn = string.Format("Hidden Column {0}", i)
                        });
                    }
    
                    gridView.DataSource = dataColumns;
                    gridView.DataBind();
                }
            }
    
            protected void btnExport_Click(object sender, EventArgs e)
            {
                List<MyDataColumn> dataColumnsToExport = new List<MyDataColumn>();
    
                foreach (GridViewRow row in gridView.Rows) 
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox cb = row.FindControl("CheckBoxID") as CheckBox;
    
                        if (cb != null && cb.Checked)
                        {
                            Label lblVisibleColumn = row.FindControl("lblVisibleColumn") as Label;
                            Label lblHiddenColumn = row.FindControl("lblHiddenColumn") as Label;
    
                            dataColumnsToExport.Add(new MyDataColumn()
                            {
                                visibleColumn = lblVisibleColumn.Text,
                                hiddenColumn = lblHiddenColumn.Text
                            });
                        }
                    }
                }
    
                GridView gridViewToExport = new GridView();
                gridViewToExport.DataSource = dataColumnsToExport;
                gridViewToExport.DataBind();
    
                //Do Something With gridViewToExport
                //GridViewExportUtil.Export("GridView.xls", gridViewToExport);
            }
