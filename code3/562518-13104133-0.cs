    @using (Html.BeginForm("action", 
                           "controller", 
                           new { brand = ViewContext.RouteData.Values["brand"],
                                 model = ViewContext.RouteData.Values["model"] },
                                 FormMethod.Post))
    {
        @Html.DropDownListFor(m => m.Color, Model.Colors)
        @Html.DropDownListFor(m => m.Price, Model.Prices)
        <input type="submit" value="Search" />
    
    }
