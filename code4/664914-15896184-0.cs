    public bool Execute(Item item, ID commandId, string comment)
    {
        var workflowId = item[FieldIDs.Workflow];
        if (String.IsNullOrEmpty(workflowId))
        {
            throw new WorkflowException("Item is not in a workflow");
        }
        IWorkflow workflow = item.Database.WorkflowProvider.GetWorkflow(workflowId);
        var workflowResult = workflow.Execute(commandId.ToString(), item, comment, false, new object[0]);
        if (!workflowResult.Succeeded)
        {
            var message = workflowResult.Message;
            if (String.IsNullOrEmpty(message))
            {
                message = "IWorkflow.Execute() failed for unknown reason.";
            }
            throw new Exception(message);
        }
        return true;
    }
