    foreach (PluginAssembly tempPluginAssembly in pluginAssemblyList)
    {
        if (!tempPluginAssembly.Name.StartsWith("Microsoft.Crm"))
        {
            var pluginList = from plugins in xrmContext.PluginTypeSet
                             join steps in xrmContext.SdkMessageProcessingStepSet on plugins.PluginTypeId equals steps.PluginTypeId.Id
                             where plugins.PluginAssemblyId.Id == tempPluginAssembly.Id
                             select new
                             {
                                 plugins,
                                 steps
                             };
            //_XrmContext.PluginTypeSet.Where(Plugin => Plugin.PluginAssemblyId.Id == tempPluginAssembly.Id).ToList();
            foreach (var plugin_step in pluginList)
            {
                if (plugin_step.plugins.IsWorkflowActivity == false)
                {
                    writer.WriteLine(new string[] { tempPluginAssembly.Name, tempPluginAssembly.Description, plugin_step.plugins.Name, String.Empty });
                    ++pluginCount;
                }
            }
        }
    }
