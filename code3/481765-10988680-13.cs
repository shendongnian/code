    @(Html.Telerik().Grid(Model)
      .Name("Grid")
      .Columns(columns =>
      {
        columns.Bound(o => o.Name)
                .Aggregate(aggregates => aggregates.Count())
                .FooterTemplate(@<text>Total Count: @item.Count</text>)
                .GroupFooterTemplate(@<text>Count: @item.Count</text>);
        columns.Bound(o => o.Start)
                .Template(@<text>@item.Start.ToShortDateString()</text>)
                .Aggregate(aggreages => aggreages.Max())
                .FooterTemplate(@<text>Max: @item.Max.Format("{0:d}")</text>)
                .GroupHeaderTemplate(@<text>Max: @item.Max.Format("{0:d}")</text>)
                .GroupFooterTemplate(@<text>Max: @item.Max.Format("{0:d}")</text>);
        columns.Bound(o => o.Value)
                .Width(200)
                .Aggregate(aggregates => aggregates.Average())
                .FooterTemplate(@<text>Average: @item.Average</text>)
                .GroupFooterTemplate(@<text>Average: @item.Average</text>);
        columns.Bound(o => o.tsMilliseconds)
              .Width(100)
              .Aggregate(aggregates => aggregates.Sum())
              .Template(@<text>@TimeSpan.FromMilliseconds(@item.tsMilliseconds)</text>)
              .Title("TimeSpan")
              .FooterTemplate(
              @<text>
                    <div>Sum: @TimeSpan.FromMilliseconds( @Convert.ToDouble( @item.Sum.Value.ToString() ) ) </div>
                </text>)
              //header if you group by TimeSpan
              .GroupHeaderTemplate(@<text>@item.Title: @item.Key (Sum: @TimeSpan.FromMilliseconds(@Convert.ToDouble(@item.Sum.Value.ToString())))</text>)
              //footer for grouping
              .GroupFooterTemplate(@<text>Sum: @TimeSpan.FromMilliseconds(@Convert.ToDouble(@item.Sum.Value.ToString()))</text>);
      })
        .Sortable()
        .Groupable(settings => settings.Groups(groups => groups.Add(o => o.Start)))
    ) 
