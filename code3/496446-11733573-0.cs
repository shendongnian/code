    <div class="DataGridXScroll">
        @(Html.Telerik().Grid(Model)
        .Name("grvSalesSummary")
        .DataKeys(keys => keys.Add(k => k.Unit_Code))
        .Columns(column =>
        {
            column.Bound(s => s.Zone_Name).Width(100).HtmlAttributes(new { @class = "GridColumnLeftAlign" }).Hidden(true)
                .GroupHeaderTemplate(@<text>Zone: @item.Key</text>);
            column.Bound(s => s.Region_Name).Width(100).HtmlAttributes(new { @class = "GridColumnLeftAlign" }).Hidden(true)
                .GroupHeaderTemplate(@<text>Region: @item.Key</text>);
            column.Bound(s => s.Unit_Code).Width(100).HtmlAttributes(new { @class = "GridColumnLeftAlign" });
            column.Bound(s => s.Unit_Name).Width(150).HtmlAttributes(new { @class = "GridColumnLeftAlign" });
            
            column.Bound(s => s.TotalCustomer).Width(70).HtmlAttributes(new { @class = "GridColumnRightAlign" })
                 .Aggregate(aggreages => aggreages.Sum())
                    .Format("{0:N}")
                    .FooterTemplate(@<text> @item.Sum.Format("{0:N}") </text>)
                    .GroupFooterTemplate(@<text>@item.Sum.Format("{0:N}")</text>);
            
            column.Bound(s => s.TotalActiveCustomer).Width(70).HtmlAttributes(new { @class = "GridColumnRightAlign" })
                 .Aggregate(aggreages => aggreages.Sum())
                    .Format("{0:N}")
                    .FooterTemplate(@<text> @item.Sum.Format("{0:N}") </text>)
                    .GroupFooterTemplate(@<text>@item.Sum.Format("{0:N}")</text>);
            
            column.Bound(s => s.NoOfSalesInCurrentMonth).Width(70).HtmlAttributes(new { @class = "GridColumnRightAlign" })
                 .Aggregate(aggreages => aggreages.Sum())
                    .Format("{0:N}")
                    .FooterTemplate(@<text> @item.Sum.Format("{0:N}") </text>)
                    .GroupFooterTemplate(@<text>@item.Sum.Format("{0:N}")</text>);
            
            column.Bound(s => s.TotalRecoveredWithoutDP).Width(100).HtmlAttributes(new { @class = "GridColumnRightAlign" })
                 .Aggregate(aggreages => aggreages.Sum())
                    .Format("{0:N}")
                    .FooterTemplate(@<text> @item.Sum.Format("{0:N}") </text>)
                    .GroupFooterTemplate(@<text>@item.Sum.Format("{0:N}")</text>);
            
            column.Bound(s => s.CollectionInCurrentMonth).Width(100).HtmlAttributes(new { @class = "GridColumnRightAlign" })
                 .Aggregate(aggreages => aggreages.Sum())
                    .Format("{0:N}")
                    .FooterTemplate(@<text> @item.Sum.Format("{0:N}") </text>)
                    .GroupFooterTemplate(@<text>@item.Sum.Format("{0:N}")</text>);
            
            column.Bound(s => s.TotalOverdue).Width(70).HtmlAttributes(new { @class = "GridColumnRightAlign" })
                 .Aggregate(aggreages => aggreages.Sum())
                    .Format("{0:N}")
                    .FooterTemplate(@<text> @item.Sum.Format("{0:N}") </text>)
                    .GroupFooterTemplate(@<text>@item.Sum.Format("{0:N}")</text>);
            
            column.Bound(s => s.TotalAdvance).Width(70).HtmlAttributes(new { @class = "GridColumnRightAlign" }) .Aggregate(aggreages => aggreages.Sum())
                    .Format("{0:N}")
                    .FooterTemplate(@<text> @item.Sum.Format("{0:N}") </text>)
                    .GroupFooterTemplate(@<text>@item.Sum.Format("{0:N}")</text>);
            
            column.Bound(s => s.TotalOutstanding).Width(80).HtmlAttributes(new { @class = "GridColumnRightAlign" })
                 .Aggregate(aggreages => aggreages.Sum())
                    .Format("{0:N}")
                    .FooterTemplate(@<text> @item.Sum.Format("{0:N}") </text>)
                    .GroupFooterTemplate(@<text>@item.Sum.Format("{0:N}")</text>);
    
            column.Template(@<a href="http://172.25.40.50/MonthlyEntrySales/SalesReports.aspx?lc=@item.Unit_Code" target="_blank">Show</a>).Width(50);
    
            column.Bound(s => s.FinalizedByRM).Format("{0:dd-MMM-yyyy}").Width(90).HtmlAttributes(new { @class = "GridColumnLeftAlign" });
            column.Bound(s => s.FinalizedByZM).Format("{0:dd-MMM-yyyy}").Width(90).HtmlAttributes(new { @class = "GridColumnLeftAlign" });
            column.Bound(s => s.FinalizedByHO).Format("{0:dd-MMM-yyyy}").Width(90).HtmlAttributes(new { @class = "GridColumnLeftAlign" });
    
            column.Template(@<a href="#" onclick="return SaveSalesStatus('@item.Unit_Code','@item.FinalizedByRM','@item.FinalizedByZM','@item.FinalizedByHO');">Save</a>).Width(50);
        })
        .Selectable()
        .Scrollable(scroll => scroll.Height(300))
        .Groupable(settings => settings.Groups(group =>
        {
            group.Add(g => g.Zone_Name);
            group.Add(g => g.Region_Name);
    
        }).Visible(false))
        )
    </div>
