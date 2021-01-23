    @Html.DevExpress().GridView(
        settings =>
        {
           var actionCol = settings.Columns.Add("Action");
           actionCol.SetDataItemTemplateContent(() =>
           { 
              Html.ActionLink("Action", "SomeAction", "SomeController", new { myParam =    Model.Param });
        } );
