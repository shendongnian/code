            <% Html.Telerik().Window()
           .Name("TelerikWindow")
           .Title("Grid in Window")
           .Draggable(true)
           .Modal(true)
           .Content(() =>
           { %>
        <%= Html.Telerik().Grid(Model)
                .Name("TelerikGrid")
                .Columns(columns =>
                {
                    columns.Bound(c => c.CustomerID);
                    columns.Bound(c => c.CompanyName);
                    columns.Bound(c => c.ContactName);
                    columns.Bound(c => c.Address);
                    columns.Bound(c => c.City);
                })
                .Pageable(pageSettings => pageSettings.Enabled(true).PageSize(10))
        %>
        <%})
           .Render();
        %>
