    private void AddHandler(ComboBox c, Action<object, EventArgs> e)
    {
       c.SelectedIndexChanged += e;
    }
    
    private void RemoveHandler(ComboBox c, Action<object, EventArgs> e)
    {
       c.SelectedIndexChanged -= e;
    }
