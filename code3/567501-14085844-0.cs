    ...
    // get workflow tasks for SPListItem object item
    if (item != null && item.Workflows != null && item.Workflows.Count > 0)
    {
        try
        {
            var workflows = site.WorkflowManager.GetItemActiveWorkflows(item);
            foreach (SPWorkflow workflow in workflows)
            {
                // match on some indentifiable attribute of your custom workflow
                // the history list title is used below as an example
                if (workflow.ParentAssociation.HistoryListTitle.Equals(Constants.WORKFLOW_HISTORY_LIST_TITLE))
                {
                    var workflowTasks = workflow.Tasks;
                    if (workflowTasks != null && workflowTasks.Count > 0)
                    {
                        // do work on the tasks
                    }
                }
            }
        }
        catch
        {
            // handle error
        }
    }
    ...
