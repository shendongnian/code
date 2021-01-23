    @{
        @Html.Kendo().Grid(Model).Name("grid").Columns(columns =>
        {
          //...
        })
        .Selectable(selectable => selectable.Mode(GridSelectionMode.Single)))
    }
