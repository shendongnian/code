    @Html.DropDownList(
        "Country", 
        new SelectList(Model.CountryList, "Value", "Text", Model.CountryList.SelectedValue),
        new { data_url = Url.Action("GetRegionList", "ControllerName") }
    )
