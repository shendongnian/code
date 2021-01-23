    /// <summary> Occurrs whenever the Control gets visible. </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridView_VisibleChanged(object sender, EventArgs e)
    {
        if (dataGridView.Visible)
        {
            DataGridView_AutoSizeColumn();
            DataGridView_CentreHeaders();
            // Etc...
        }
    }
    
