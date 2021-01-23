    public Dictionary<int, string> TaskTitles {get;set;}
    public void Initialise()
    {
	TaskTitles = new Dictionary<int, string>();
	
	foreach(var taskTitle in BestClass.taskTitles)
		TaskTitles.Add(taskTitle);
	
	if(!TaskTitles.Any(t => t.Value == tkttid.Value))
		TaskTitles.Add(tkttid);
		
	
    }
