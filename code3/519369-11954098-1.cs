    public void EventTypeFilter()
    {
        DataTable table = dataSourceDataSet.Tables["TableName"];        
        table.DefaultView.RowFilter = string.Format("EventType <> '{0}'", "Exam");
        EventsDataGridView.DataSource = table;           
    }
