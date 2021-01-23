    private void LoadDataGridView() {
        // Fill a DataAdapter using the SelectCommand.
        DataAdapter da = null;
        // The Sql code here
        
        // In case something fails, bail out of the method.
        if (da == null) return;
        
        // Clear the DataSource or else you'll get double of everything.
        if (exerciseListDataGridView.DataSource != null) {
            exerciseListDataGridView.DataSource.Clear();
            exerciseListDataGridView.DataSource = null;
        }
        
        // I'm doing this off the top of my head, you may need to fill a DataSet here.
        exerciseListDataGridView.DataSource = da.DefaultView;
        
    }
