    @model string
    @{
        ViewBag.Recursion = (int) ViewBag.Recursion + 1;
    }
    @if (Model != null)
    {
        @Html.Partial("_RecursiveCategory", Model.Parent)
        @Model
    }
    else
    {
        <li>@Html.ActionLink(Model.Name, "Index", "Categories", new {Model.Id, name = Model.FriendlyName}, null)</li>
    }
