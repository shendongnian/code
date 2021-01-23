        public bool UpdateWorkflow(WorkflowState newWorkflowState, Item item)
        {
            bool successful = false;
            if (newWorkflowState != null && item != null)
            {
                WorkflowState currentWorkflowState = GetWorkflowStateForItem(item);
                if (currentWorkflowState != newWorkflowState)
                {
                    IWorkflow workflow = GetWorkflowOfItem(item);
                    if (workflow != null)
                    {
                        List<WorkflowCommand> applicableWorkflowCommands = workflow.GetCommands(currentWorkflowState.StateID).ToList();
                        foreach (var applicableWorkflowCommand in applicableWorkflowCommands)
                        {
                            Item commandItem = Sitecore.Data.Database.GetDatabase("master").GetItem(applicableWorkflowCommand.CommandID);
                            string nextStateId = commandItem["Next state"];
                            if (nextStateId == newWorkflowState.StateID)
                            {
                                WorkflowResult workflowResult = workflow.Execute(applicableWorkflowCommand.CommandID, item, "", false);
                                successful = workflowResult.Succeeded;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    successful = true;
                }
            }
            return successful;
        }
        public WorkflowState GetWorkflowStateForItem(Item item)
        {
            var workflow = GetWorkflowOfItem(item);
            return workflow != null ? workflow.GetState(item) : null;
        }
        public IWorkflow GetWorkflowOfItem(Item item)
        {
            var database = Factory.GetDatabase("master");
            return database.WorkflowProvider.GetWorkflow(item);
        }
