    @(Html.Telerik().Grid(Model)
      .Name("Grid")
      .Columns(columns =>
      {
        columns.Bound(o => o.Name)
                .Aggregate(aggregates => aggregates.Count())
                .FooterTemplate(@<text>Total Count: @item.Count</text>)
                .GroupFooterTemplate(@<text>Count: @item.Count</text>);
        columns.Bound(o => o.start)
                .Width(200)
                .Aggregate(aggreages => aggreages.Max())
          //.Format("{0:c}")
                .FooterTemplate(@<text>Max: @item.Max</text>)
                .GroupFooterTemplate(@<text>Max: @item.Max</text>);
        columns.Bound(o => o.Value)
                .Width(200)
                .Aggregate(aggregates => aggregates.Average())
                .FooterTemplate(@<text>Average: @item.Average</text>)
                .GroupFooterTemplate(@<text>Average: @item.Average</text>);
        columns.Bound(o => o.ts)
                .Width(100)
                .Aggregate(aggregates => aggregates.Count().Min().Max())
                .FooterTemplate(
                @<text>
                    <div>Min: @item.Min</div>
                    <div>Max: @item.Max</div>
                </text>)
                .GroupHeaderTemplate(@<text>@item.Title: @item.Key (Count: @item.Count)</text>);
        columns.Bound(o => o.tsDays)
              .Width(100)
              .Aggregate(aggregates => aggregates.Sum())
              .FooterTemplate(
              @<text>
                    <div>Sum: @item.Sum Days</div>
                </text>)
              .GroupHeaderTemplate(@<text>@item.Title: @item.Key (Sum: @item.Sum)</text>);
      })
        .Sortable()
