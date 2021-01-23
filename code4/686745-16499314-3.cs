    public void ValuesChangedHandler(object sender, EventArgs e)
    {
        // do something with the new value
    }
    public StudentListViewModel()
    {
           yourModel.ValuesChanged += ValuesChangedHandler;
    }
