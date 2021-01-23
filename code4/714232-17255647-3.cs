    public ActionResult MyAction(EmployeeViewModel m)
    {
        var person = new Person();
        person.Job = JobFactory.GetJob(m.JobType);
        ...
    }
