    // view interface
    public interface MVPSampleView
    {
        Telerik.Web.UI.RadGrid myGrid { get; }
    }
    
    // presenter
    protected readonly IGridView _view;
    public GridPresenter(IGridView view)
    {
        _view = view;
        
        _view.myGrid.UpdateCommand += new Telerik.Web.UI.GridCommandEventHandler(onUpdateCommand);
        _view.myGrid.InsertCommand += new Telerik.Web.UI.GridCommandEventHandler(onInsertCommand);
        _view.myGrid.EditCommand += new Telerik.Web.UI.GridCommandEventHandler(onEditCommand);
    }
    private void onUpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        // Code for updating 
    }
    private void onInsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        // Code for inserting
    }
    
    private void onEditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        // Code for editcommand
    }
