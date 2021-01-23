    @{
    Html.EnableClientValidation(true);
    
    var grid = Html.DevExpress().GridView(
        settings =>
        {
            //your code
            //Add this code to initialize the rows for a New Row
            settings.InitNewRow = (sender, e) =>
            {
                    e.NewValues["JobStatusSortOrder"] = 0; // set the default value as 0
            };
        });
    }@grid.Bind(Model.JobStatus.ToList()).GetHtml()
    
        
