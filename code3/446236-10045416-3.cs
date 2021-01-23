    @inherits System.Web.Mvc.WebViewPage<USState>
    @Html.DropDownListFor(m => m, new SelectList((IEnumerable<USState>)ViewBag.USStatesAll,
        "Id",
        "Name",
        Model==null?1:Model.Id),
        "Choose--")
