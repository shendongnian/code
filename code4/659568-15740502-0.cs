        private void OnCreateTask_MethodInvoking(object sender, EventArgs e)
        {
            taskId1 = Guid.NewGuid();
            //   SPContentTypeId myContentTypeId=new SPContentTypeId("0x01080100e73fd5f172cb40d8a5dca97fad7a58b8");
            SPContentType myContentType = SPContext.Current.Web.ContentTypes["Powerfull Approval Workflow Task"];
            CreateTaskApproval_ContentTypeID = myContentType.Id.ToString();
            #region Enable ContentTypes
            if (this.workflowProperties.TaskList.ContentTypesEnabled != true)
            {
                workflowProperties.TaskList.ContentTypesEnabled = true;
            }
            bool contenTypeExists = false;
            foreach (SPContentType contentType in workflowProperties.TaskList.ContentTypes)
            {
                if (contentType.Name == myContentType.Name)
                {
                    contenTypeExists = true;
                    break;
                }
            }
            if (contenTypeExists != true)
            {
                workflowProperties.TaskList.ContentTypes.Add(myContentType);
            }
            myContentType.EditFormUrl = "_layouts/SequentialWorkflow/TaskEdit/TaskEditForm.aspx";
            myContentType.DisplayFormUrl = "_layouts/SequentialWorkflow/TaskEdit/TaskEditForm.aspx";
            myContentType.Update();
            #endregion
            taskProperties.PercentComplete = (float)0.0;
            taskProperties.AssignedTo = myInstantiationData.User;
            taskProperties.DueDate = myInstantiationData.DueDate;
            taskProperties.Description = myInstantiationData.Request;
            taskProperties.StartDate = DateTime.Now;
            taskProperties.Title = "Please approve " + this.workflowProperties.Item.DisplayName;
        }
