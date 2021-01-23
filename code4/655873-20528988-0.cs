    @(Html.Telerik().Grid(Model)
            .Name("SiteGrid")
            .Columns(columns =>
            {
                columns.Bound(o => o.PKComID).Width(50);
                columns.Bound(o => o.CompanyName).Width(50);      
            })    
               .ClientEvents(events => events.OnComplete("getCompanyDetails"))
              .Pageable(paging => paging.PageSize(15).Style(GridPagerStyles.NextPreviousAndNumeric).Position(GridPagerPosition.Bottom))
                     .Sortable()
        ) 
