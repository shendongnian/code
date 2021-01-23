    @(
        Html.Telerik().Grid(Model).Name("grid")
            .Columns( columns =>
                          {
                              columns.Template(
                                  @<text> bla bla </text>
                              );
                              columns.Bound(p => p.ProductName).Title("Product");
                          }).Pageable().Sortable()
    )
