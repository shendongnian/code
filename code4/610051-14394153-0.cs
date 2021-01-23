    protected override void InitializeCulture() 
    { 
        base.InitializeCulture();
        var selectedCulture = Request.Form["DowndownListName"];
        if (!string.IsNullOrEmpty(selectedCulture))
        {
           ...
        }
    }
