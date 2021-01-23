    @model IGrouping<string, MvcApplication1.Models.Row>
    @{
        ViewBag.Title = "Home Page";
    }
    
    @using(Html.BeginForm("Post", "Home", FormMethod.Post))
    {
        @Html.EditorForModel("IGrouping")
        <button type="submit">Submit</button>
    }
