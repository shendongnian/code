    int iTaskIndex = 1;
    for (int iTaskNameIndex = 1; iTaskNameIndex <= 5; iTaskNameIndex++)
    {
    	Task task = project.Tasks.Add("Task_" + iTaskNameIndex.ToString(), iTaskIndex);
    	if (iTaskIndex > 1)
    		task.OutlineOutdent();
    	Task subTask = project.Tasks.Add("SubTaskName_" + iTaskNameIndex.ToString(), iTaskIndex + 1);
    	subTask.OutlineIndent();
    	iTaskIndex += 2;
    }
