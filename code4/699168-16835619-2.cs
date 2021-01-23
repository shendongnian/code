    private void Init()
    {
        var bs = new BindingSource(...);
        bs.AddingNew += new AddingNewEventHandler(bs_AddingNew);
    }
    void bs_AddingNew(object sender, AddingNewEventArgs e)
    {
        string name = AskForName();
        e.NewObject = CreateLeage(name);
    }
