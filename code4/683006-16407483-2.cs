    @{
        // Not good way, with reflection. Have to check for all the various dataannotations
        // yourself for each property.
        var properties = Model.GetType().GetProperties();
        foreach (var property in properties)
        {
            @property.Name
        }
        // Better way (sort of), loop the data which is already built
        // in the view with metadata properties.
        foreach (var property in ViewData.ModelMetadata.Properties)
        {
            @property.DisplayName
        }
    }
