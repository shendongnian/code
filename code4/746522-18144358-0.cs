    protected void ExecuteYourPlugin(LocalPluginContext localContext)
    {
        IPluginExecutionContext pluginContext = localContext.PluginExecutionContext;
        // Get Target Entity
        var updateEntity = (Entity)pluginContext.InputParameters["Target"];
        // Get PreImage Entity
        var preEntity = (Entity)localContext.PluginExecutionContext.PreEntityImages["PreImage"];
        // Is in Update
        if(localContext.PluginExecutionContext.MessageName.ToLower() == "update")
        {
            var fieldName = string.Empty;
                // If Contains, Extract value from Target Entity
                if(updateEntity.Contains("new_fieldname"))
                {
                    fieldName = updateEntity["new_fieldname"].toString();
                }
                // Else extract the value from preImage
                else if(preEntity .Contains("new_fieldname"))
                {
                    fieldName = preEntity["new_fieldname"].toString();
                }
        }
    }
