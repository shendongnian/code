    [HttpGet]
    public JsonResult GetTasks()
    {
        //Create an array to hold all of the task objects
        var tasks = new List<Task> { };
    
        //Execute the select statement and get back a SqlDataReader object
        DataTable table = DataAccess.ExecuteSelect("select Id, Name, Description, Starting, Ending from Tasks");
    
        foreach (DataRow dr in table.Rows)
        {
            //Assign values to the task object
            Task task = new Task((int)dr["Id"],
                                (string)dr["Name"],
                                (string)dr["Description"],
                                (DateTime)dr["Starting"],
                                (DateTime)dr["Ending"]);
    
            //Add task object to list of task objects
            tasks.Add(task);
        }
    
        return Json(tasks, JsonRequestBehavior.AllowGet);
    }
