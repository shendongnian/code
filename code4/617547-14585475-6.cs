    @model IEnumerable<PersonViewModel>
    @{
        var grid = new WebGrid();
    }
    
    @grid.GetHtml(
        grid.Columns(
            grid.Column("Name"),
            grid.Column("Age"),
            grid.Column("Country")
        )
    )
