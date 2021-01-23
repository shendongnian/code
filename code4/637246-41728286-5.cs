    var dtX = someData.ToDataTable();
    
    dgvB.SuspendLayout();
    dgvB.DataSource = dtX;
    // process extended props
    foreach (DataColumn dc in dtX.Columns)
    {
        // no need to test, the code adds them everytime
        //if (dc.ExtendedProperties.ContainsKey("DisplayName"))
        //{ 
            dgvB.Columns[dc.ColumnName].HeaderText = dc.ExtendedProperties["DisplayName"].ToString(); 
        //}
        //if (dc.ExtendedProperties.ContainsKey("Browsable"))
        //{
            dgvB.Columns[dc.ColumnName].Visible = (bool)dc.ExtendedProperties["Browsable"];
        //}
    }
    dgvB.ResumeLayout();
