    public void UpdateDataGrid(bool newInsert = false)
    {
        //ThreadSafe (updating datagridview from AddEventForm is not allowed otherwise 
        if (InvokeRequired)
        {
            Invoke(new Action(() => UpdateDataGrid(newInsert)));
        }
        else
        {
            Util.PopulateDataGridView(ref this.EventsDataGridView,newInsert);
        }
    }    
