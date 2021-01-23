    protected void RadAutoCompleteBox1_EntryAdded(object sender, AutoCompleteEntryEventArgs e)
    {
        // Label1 is made up here just for example's sake
        // e.Entry.Text will give you the name selected
        // e.Entry.Value will give you the ID selected
        Label1.Text = e.Entry.Value + " was added.";
    }
