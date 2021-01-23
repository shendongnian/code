    private static Dictionary<string, SourceLocation> CreateSourceLocationMapping(
        IDesignerDebugView debugView,
        ModelService modelService)
    {
        var nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
        var debuggerServiceType = typeof(DebuggerService);
        var ensureMappingMethodName = "EnsureSourceLocationUpdated";
        var mappingFieldName = "instanceToSourceLocationMapping";
        var ensureMappingMethod = debuggerServiceType.GetMethod(ensureMappingMethodName, nonPublicInstance);
        var mappingField = debuggerServiceType.GetField(mappingFieldName, nonPublicInstance);
        if (ensureMappingMethod == null)
            throw new MissingMethodException(debuggerServiceType.FullName, ensureMappingMethodName);
        if (mappingField == null)
            throw new MissingFieldException(debuggerServiceType.FullName, mappingFieldName);
        var rootActivity = modelService.Root.GetCurrentValue() as Activity;
        if (rootActivity != null) 
            WorkflowInspectionServices.CacheMetadata(rootActivity);
        ensureMappingMethod.Invoke(debugView, new object[0]);
        var mapping = (Dictionary<object, SourceLocation>) mappingField.GetValue(debugView);
        return (from pair in mapping
                let activity = pair.Key as Activity
                where activity != null
                select new {activity.Id, pair.Value})
            .ToDictionary(p => p.Id, p => p.Value);
    }
