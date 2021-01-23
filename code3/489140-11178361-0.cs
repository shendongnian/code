    this.saveContactTask.Completed += new EventHandler<SaveContactResult>(saveContactTask_Completed);
    
    private void saveContactTask_Completed(object sender, SaveContactResult e)
    {
        switch (e.TaskResult)
        {
            case TaskResult.OK:
            MessageBox.Show("Contact is successfully saved.");
            break;
            case TaskResult.Cancel:
            MessageBox.Show("The user canceled the task.");
            break;
            case TaskResult.None:
            MessageBox.Show("NO information regarding the task result is available.");
            break;
        }
    }
