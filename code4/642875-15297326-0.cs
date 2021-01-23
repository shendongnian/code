    public class MyGridView : GridView
    {
        TextBox txtSearch;
        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            int numRows = base.CreateChildControls(dataSource, dataBinding);
            // Create a new row
            GridViewRow rowSearch = base.CreateRow(-1, -1, DataControlRowType.DataRow, DataControlRowState.Normal);
            
            //convert the existing columns into an array, initialize and then add the row to the previously created table
            DataControlField[] fields = new DataControlField[this.Columns.Count];
            this.Columns.CopyTo(fields, 0);
            this.InitializeRow(rowSearch, fields);
            TableCell cellSearch = new TableCell();
            rowSearch.Cells.Add(cellSearch);
            txtSearch = new TextBox();
            txtSearch.Text = this.SearchTextboxDefaultValue;
            txtSearch.ID = "txtSearch";
            txtSearch.AutoPostBack = true;
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            cellSearch.Controls.Add(txtSearch);
            this.Controls[0].Controls.Add(rowSearch); // Controls[0] is a Table element
            return numRows;
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = (sender as TextBox).Text;
            DataTable dt = new DataTable();
            // We fill in dt with results, and rebind it
            this.DataSource = dt;
            this.DataBind();
        }
    }
