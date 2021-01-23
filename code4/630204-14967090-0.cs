    var grid = new WebGrid(Model);
    var cols = new List<WebGridColumn>();
    //add some columns
    var table = grid.Table(columns: cols, footer: @<text>Footer</text>);
    ....
    ....
    @table
