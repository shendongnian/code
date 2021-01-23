    @model IList<Test>
    @{
        var grid = new WebGrid(Model);
    }
    @grid.GetHtml()
