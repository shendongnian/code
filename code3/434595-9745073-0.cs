    <%Html.Grid(Model)
        .Columns(column =>
                {%>
                <% <td><a id="<%= c.Desc %>_<%= c.No %>" href="#" class="expand"></a></td>                
                <% }).Attributes(c => new Dictionary<string, object> { { "padding-left", " 5px" } });                
                    column.For(c => c.Date).Format("{0:dd/MM/yyyy}").Named("Date");
                    column.For(c => c.Desc).Named("Description");                   
                   }).Attributes(id => "example")
                .Empty("----------- No Ledger Details for current month/Search -----------    ").Render();%>
