    @model MyViewModel
    @{
        var grid = new WebGrid(Model.Values);
        var columns = Model.Columns.Select(x => grid.Column(x));
    }
    
    @grid.GetHtml(columns: columns)
    // and then we could have dropdowns and other stuff
    @Html.DropDownListFor(x => x.SelectedCustomerId, Model.Customers, "-- customer --")
    @Html.DropDownListFor(x => x.SelectedJobId, Model.Jobs, "-- job --")
