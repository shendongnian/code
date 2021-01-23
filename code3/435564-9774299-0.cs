    protected virtual void OnRowClicked(GridViewRowClickedEventArgs e)
    {
       EventHandler<GridViewRowClickedEventArgs> temp = RowClicked ;
        //raise the RowClicked event
        if (temp != null)
        {
            temp(this, e);
        }
    }
    public event EventHandler<GridViewRowClickedEventArgs> RowClicked;
