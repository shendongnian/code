            if (item.Database.Name == "web")
            {
                throw new Exception("Can not execute workflow command in web database");
            }
            if (String.IsNullOrEmpty(item[FieldIDs.WorkflowState]))
            {
                throw new Exception("Workflow state is not set for the item");
            }
            Item stateItem = ItemManager.GetItem(wf.GetState(item), Language.Current, Version.Latest, item.Database, SecurityCheck.Disable);
            if (stateItem == null)
            {
                throw new Exception("Workflow state " + item[FieldIDs.WorkflowState] + " is not a part of " + wf.WorkflowID + " workflow");
            }
            if (stateItem.Axes.GetChild(ID.Parse(SitecoreItems.MediaWorkflowApproveCommand)) == null)
            {
                throw new Exception("Workflow state " + stateItem.ID + " does not have a child command with id " + SitecoreItems.MediaWorkflowApproveCommand);
            }
