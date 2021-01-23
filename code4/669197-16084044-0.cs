    public class Column : BoundField
    {
        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            base.InitializeCell(cell, cellType, rowState, rowIndex);
            if (cellType == DataControlCellType.Footer)
            {
                TextBox txtFilter = new TextBox();
                // Removing this worked
                //txtFilter.ID = Guid.NewGuid().ToString(); 
                txtFilter.Text = "";
                txtFilter.AutoPostBack = true;
                txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
                cell.Controls.Add(txtFilter);
            }
        }
        protected void txtFilter_TextChanged(object sender, EventArgs e)
        {
            // Never get here
        }
    }
