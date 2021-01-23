    //Your code is modified a little.
    var groupColumn = new DataGridViewComboBoxColumn();
    groupColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    DataTable dtcategori = cb.GetAllDataCategori();
    groupColumn.Name = "Group";
    groupColumn.HeaderText = Resources.GroupName;
    //Create a BindingSource from your DataTable
    BindingSource bs = new BindingSource(dtcategori,"");
    groupColumn.DataSource = bs;
    bs.PositionChanged += (s,e) => {
       //Filter for items which have the selected GroupID
       ((DataTable)((DataGridViewComboBoxColumn)DataGridViewFactor.Columns["Services"]).DataSource).DefaultView.RowFilter =
                    string.Format("GroupID='{0}'",((DataRowView)bs.Current).Row["ID"]);
       //Set the initial value of the corresponding cell in serviceColumn
       DataGridViewFactor.CurrentRow.Cells["Services"].Value = ((DataTable)((DataGridViewComboBoxColumn)DataGridViewFactor.Columns["Services"]).DataSource).DefaultView.ToTable().Rows[0]["Name"];
    };
    //-------------------------------------------
    groupColumn.ValueMember = "ID";
    groupColumn.DisplayMember = "Name";
    groupColumn.Width = 100;
    this.DataGridViewFactor.Columns.Add(groupColumn);
    var serviceColumn = new DataGridViewComboBoxColumn();
    serviceColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    //var categoriId = Convert.ToInt32(groupColumn.);
    // DataTable dtServices = sb.ServiceGetById(categoriId);
    DataTable dtServices = sb.GetAllDataServices();
    serviceColumn.Name = "Services";
    serviceColumn.HeaderText = Resources.Service;
    serviceColumn.DataSource = dtServices;
    serviceColumn.ValueMember = "ID";
    serviceColumn.DisplayMember = "Name";
    serviceColumn.Width = 100;
    this.DataGridViewFactor.Columns.Add(serviceColumn);
    
    //Because filtering this way can make some cell have a value which is not contained in the DataGridViewComboBoxColumn.Items, we have to handle the DataError
    private void DataGridViewFactor_DataError(object sender, DataGridViewDataErrorEventArgs e){
        //We're interested only in DataGridViewComboBoxColumn
        if(DataGridViewFactor.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn){
            e.Cancel = true;
        }
    }
    //Because when you filter on a row, the DataGridViewComboBoxColumn.DataSource with
    //the filtered DefaultView will apply on all the rows in the same DataGridViewComboBoxColumn, we have to apply the filter for each row if it is selected
    private void DataGridViewFactor_SelectionChanged(object sender, EventArgs e)
        {            
            ((DataTable)((DataGridViewComboBoxColumn)DataGridViewFactor.Columns["Services"]).DataSource).DefaultView.RowFilter =
               string.Format("GroupID='{0}'", DataGridViewFactor.CurrentRow.Cells["Group"].Value);            
        }
    //Because when you filter on a row, the DataSource DefaultView of the groupColumn will be changed (limited to fewer items) and there will be cells in that column having values which are not contained in the filtered items. Those cells will not be displayed when you move the mouse over. This CellPainting event handler is to help them look normal.
    private void DataGridViewFactor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e){
        if (e.RowIndex > -1 && e.ColumnIndex > -1)
        {
                if (e.Value != null)
                {
                    e.Handled = true;
                    e.PaintBackground(e.CellBounds, true);
                    StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString(e.Value.ToString(), DataGridViewFactor.Font, new SolidBrush(DataGridViewFactor.ForeColor), e.CellBounds, sf);
                }
        }
    }
