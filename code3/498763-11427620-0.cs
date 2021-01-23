    private void DataGridView_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        string headerName = e.Column.Header.ToString();
    
        // No need of customization.
        if (headerName == "IAmPerfect")
        {
            e.Cancel = true;
        }
    
        // Columns which requires updating.
        if (headerName == "EID")
        {
            e.Column.Header = "Employee ID";
        }
        else if (headerName == "EName")
        {
            e.Column.Header = "Employee Name";
        }
    }
