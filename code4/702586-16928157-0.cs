    public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                gvTest.DataSource = new List<string>() { "test1", "test2" };
                gvTest.DataBind();
            }
    
            private bool tableCopied = false;
            private System.Data.DataTable originalDataTable;
    
            protected void gvTest_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                    if (!tableCopied)
                    {
                        //originalDataTable = ((System.Data.DataRowView)e.Row.DataItem).Row.Table.Copy();
                        //ViewState["originalValuesDataTable"] = originalDataTable;
                        //tableCopied = true;
                        TextBox accountTextBox = (TextBox)e.Row.FindControl("AccountTextBox");
    
                        if (accountTextBox.Text == "Total Expenses")
                        {
                            e.Row.Enabled = false;
                        }
    
                    }
            }
        }
