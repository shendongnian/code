    @model ViewModel
    @* write schtml here *@
KendoGuid.cshtml
    ...
    .Columns(columns =>
    {
        columns.Bound(x => x.GridViewModelField)
            .ClientTemplate("PartialView", new ViewModel
            {
                ViewModelField = "#=GridViewModelField#",
            }).ToHtmlString());
    })
    ...
