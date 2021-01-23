    @{
        Html.Kendo().Grid(Model).Name("grid").Columns(columns =>
        {
          //...
        })
        .Selectable(selectable => selectable.Mode(GridSelectionMode.Single)))
        .Render(); //Render method provided by Kendo UI.
    }
