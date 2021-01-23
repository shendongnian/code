    private static void SetProcessParametersForSubBuild(IBuildRequest buildRequest, Dictionary<string, object> processParametersForSubBuild, IBuildDefinition buildDefinition)
    {
        var subBuildProcessParameters = WorkflowHelpers.DeserializeProcessParameters(buildDefinition.ProcessParameters);
        if (processParametersForSubBuild.Any())
        {
            foreach (var processParameter in processParametersForSubBuild)
            {
                if (subBuildProcessParameters.ContainsKey(processParameter.Key))
                {
                    subBuildProcessParameters[processParameter.Key] = processParameter.Value;
                }
                else
                {
                    subBuildProcessParameters.Add(processParameter.Key, processParameter.Value);
                }
            }
            buildRequest.ProcessParameters = WorkflowHelpers.SerializeProcessParameters(subBuildProcessParameters);
        }
    }
