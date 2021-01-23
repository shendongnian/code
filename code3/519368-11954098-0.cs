    public void EventTypeFilter()
    {
        var myDataView = dataSourceDataSet.Event.DefaultView;
        myDataView.RowFilter = string.Format("EventType <> '{0}'", "Exam");
        EventsDataGridView.DataSource = myDataView;           
    }
