    @model System.Collections.Generic.List<MvcApplication1.Models.BaseModel>
    @{
        ViewBag.Title = "CompositeView";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    <h2>
        CompositeView</h2>
    @foreach (var model in Model)
    {
        Html.RenderPartial(string.Format("_{0}", model.GetType().Name), model);
    }
