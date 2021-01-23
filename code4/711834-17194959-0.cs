    protected void BtnAdd_Click(object sender, EventArgs e) {
    	MTMSDTO m = new MTMSDTO();
    	m.TaskName = TxtTaskName.Text;
    	m.ClientName = DrpClientName.Text;
    	m.BeginDate = TxtBeginDate.Text;
    	m.DueDate = TxtDueDate.Text;
    	m.Description = TxtDescription.Text;
    	m.AssignTo = DrpAssignTo.Text;
    	m.Status = DrpStatus.Text;
    	m.PercentageComplete = DrpPercentageComplete.Text;
    
    	InsertTask(m);
    }
