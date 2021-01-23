    public event EventHandler<EventArgs> RowAdded;
    
    private void button1_Click(object sender, EventArgs e)
    {
         OnRowAddedEvent();
    }
    
    private void OnRowAddedEvent()
    {
         var listener = RowAdded;
         if (listener != null)
             listener(this, EventArgs.Empty);
    }
