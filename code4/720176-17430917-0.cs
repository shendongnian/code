    @model OilNGasWeb.ModelData.dbClient 
    @{
        ViewBag.Title = "Create";
    }
    <h2>Create County</h2>
    @Html.Partial("_CreateCounty", Model.ClientID) <!-- pass the client ID to the partial
    <div>
        @Html.ActionLink("Back to List", "Index", new { id=Model.ClientID})
    </div>
    @section Scripts {
        @Scripts.Render("~/bundles/jqueryval")
    }
