    public event EventHandler<EventArgs> RowAdded;
    
    private void btnRowAdded_Click(object sender, EventArgs e)
    {
         // insert data
         // if successful raise event
         OnRowAddedEvent();
    }
    
    private void OnRowAddedEvent()
    {
         var listener = RowAdded;
         if (listener != null)
             listener(this, EventArgs.Empty);
    }
