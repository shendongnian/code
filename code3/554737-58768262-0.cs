    private Dictionary<object, SourceLocation> UpdateSourceLocationMappingInDebuggerService()
        {    
           Dictionary<object, SourceLocation> sourceLocationMapping = new Dictionary<object, SourceLocation>();
           Dictionary<object, SourceLocation> designerSourceLocationMapping = new Dictionary<object, SourceLocation>();
           MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(this.WorkflowDesigner.Text));
           DynamicActivity activityToRun = ActivityXamlServices.Load(ms) as DynamicActivity;
           WorkflowInspectionServices.CacheMetadata(activityToRun);
           Activity documentRootElement = GetRootWorkflowElement(rootInstance);
           Activity rootActivity = GetRootRuntimeWorkflowElement(this.workflowToRun);
           var fileName = this.WorkflowDesigner.Context.Items.GetValue<WorkflowFileItem>().LoadedFile;
           SourceLocationProvider.CollectMapping(rootActivity, documentRootElement, sourceLocationMapping, fileName);
           SourceLocationProvider.CollectMapping(documentRootElement, documentRootElement, designerSourceLocationMapping, fileName);
               if (this.debuggerService != null)
                {
                    ((DebuggerService)this.debuggerService).UpdateSourceLocations(designerSourceLocationMapping);
                }
               if (designerSourceLocationMapping.Count != sourceLocationMapping.Count)
                {
                    foreach (var item in designerSourceLocationMapping)
                    {
                        if (!sourceLocationMapping.ContainsValue(item.Value))
                            sourceLocationMapping.Add(item.Key, item.Value);
                    }
                }
           this.designerSourceLocationMapping = designerSourceLocationMapping;
           return sourceLocationMapping;
       }
