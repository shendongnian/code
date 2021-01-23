    public List<Task> Tasks = new List<Task>();
    public void Test()
    {
        Tasks.Add(new Task { Id = 1, Name = "Task #1", Description = "Description task #1" });
        Tasks.Add(new Task { Id = 2, Name = "Task #2", Description = "Description task #2" });
        Tasks.Add(new Task { Id = 3, Name = "Task #3", Description = "Description task #3" });
    }
    public ActionResult Index()
    {
        Test();
        return Json(GetAllTasks(), JsonRequestBehavior.AllowGet);
    }
    public IEnumerable<object> GetAllTasks()
    {
        return Tasks.Select(GetTask);
    }
    private object GetTask(Task task)
    {
        dynamic expandoObject = new ExpandoObject();
        //your if statment block
        if (task.Id == 1)
        {
            expandoObject.Id = task.Id;
        }
        expandoObject.Name = task.Name;
        expandoObject.Description = task.Description;
        var dictionary = expandoObject as IDictionary<string, object>;
        return dictionary.ToDictionary(item => item.Key, item => item.Value);
    }
