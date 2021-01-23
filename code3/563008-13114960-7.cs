    @using MvcApplication1.Models
    @model IList<MvcApplication1.Models.BaseModel>
    
    @{
        ViewBag.Title = "title";
        //Layout = "_Layout";
    }
    <h2>title</h2>
    @using (Html.BeginForm())
    {
        for (int i = 0; i < Model.Count; i++)
         {
             @Html.EditorFor(p => p[i])
         }
        <input type="submit" value="Save" />
    }
