    @model List<Models.Misc>
    @(Html.Telerik().Grid(Model)
        .Name("Grid")
        .Columns(columns =>
        {
          columns.Bound(a => a.Id).Width(120);
          columns.Bound(a => a.Name).Width(100);
          columns.Bound(a => a.Value).Format("{0:#,##0.00}").Width(100).Title("Price");
        })
    )
