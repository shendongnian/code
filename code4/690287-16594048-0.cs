     @{
        ViewBag.Title = "Send Items";
      }
      <h2>Sent Items</h2>
      <p>
      @using (Html.BeginForm())
      {
          Html.RenderAction("AdvancedSearchEngine", "PartialViews");
      }
       @Ajax.ActionLink("Back to Selection", "MenuSelection", new {id = Model.Id}
                 new AjaxOptions { HttpMethod ="GET", 
                 InsertionMode = InsertionMode.Replace, 
                 UpdateTargetId = "results")
