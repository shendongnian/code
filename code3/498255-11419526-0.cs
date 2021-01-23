        private void Invoke_Task1_TaskChanged(object sender, ExternalDataEventArgs e)
        {
            Task1_IsCompleted = bool.Parse(task1_AfterProperties.ExtendedProperties["isFinished"].ToString());
            Task1_IsApproved = bool.Parse(task1_AfterProperties.ExtendedProperties["isApproved"].ToString());
            if (Task1_IsCompleted)
            {
                ManagerReason = task1_AfterProperties.ExtendedProperties["ManagerReason"].ToString();
            }
        }
