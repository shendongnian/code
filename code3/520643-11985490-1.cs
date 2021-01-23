    @model FileUploadModel
    @{
        // Common output code that they all do
        // Then the special stuff
        if (model.GetType().Name == "CreateBrandViewModel")
        {
            // Render the partial and pass it the model
            Html.RenderPartial("CreateBrandPartialView", Model);
        }
    }
    
