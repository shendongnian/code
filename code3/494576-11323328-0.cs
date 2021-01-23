    @Html.DevExpress().GridView(
        settings =>
        {
           var actionCol = settings.Columns.Add("Action");
           myColumn.SetDataItemTemplateContent(() =>
           { 
              Html.ActionLink("Action", "SomeAction", "SomeController", new { myParam =    Model.Param });
        } );
