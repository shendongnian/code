    <div id="accordion1" style="text-align:justify">
    @using (Html.BeginForm())
    {
        foreach (var category in Model.Categories)
        {
            <h3><u>@category.Name</u></h3>
            <div>
                <ul>    
                    @foreach (var product in Model.Product.Where(m=> m.CategoryID= category.CategoryID)
                    {
                        <li>
                            @product.Title
                            @if (System.Web.Security.UrlAuthorizationModule.CheckUrlAccessForPrincipal("/admin", User, "GET"))
                            {
                                @Html.Raw(" - ")  
                                @Html.ActionLink("Edit", "Edit", new { id = product.ID })
                            }
                            <ul>
                                <li>
                                    @product.Description
                                </li>
                            </ul>
                        </li>
                    }
                </ul>
            </div>
        }
    }  
