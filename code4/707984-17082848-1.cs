    @(Html.Kendo().Grid<MvcApplication1.Models.TestModels>()
      .Name("grid")
      .Columns(columns =>
      {
          columns.Bound(m => m.ID).Width(100);
          columns.Bound(m => m.Name).Width(700);
      })
      .DataSource(dataSource =>
          dataSource.Ajax()
          .ServerOperation(false)
                          .Read(read => read.Action("GridRead", "Home").Data("MarketData"))
          .PageSize(150)
      )
      .Pageable()
      .Sortable())
