    @model my.project.com.Models.ContentModels.GenericPageDataModel        
               
    @{
        ViewBag.Title = "My Title";
        Layout = "~/Views/Shared/_Layout.cshtml";
    
        ViewBag.heroDisplayName = @Model.HeroModel.ToDictionary(p => p.Key).FirstOrDefault(k => k.Key.Equals("DisplayName")).Value.Value;
    }
               
    <h1> @ViewBag.heroDisplayName</h1>
