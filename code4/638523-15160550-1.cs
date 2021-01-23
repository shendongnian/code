    var keys = new HashSet<string>();
    foreach (DataRow dRow in dt.Rows)
    {
        if (keys.Add(dRow["RequestNumber"].ToString()))
        {
            acList.Add(new AssignedClass
            {
                Project = dRow["Project"].ToString(),
                RequestNumber = dRow["RequestNumber"].ToString(),
                RequestId = dRow["RequestId"].ToString(),
                TaskType = dRow["TaskType"].ToString(),
                TaskId = dRow["TaskId"].ToString(),
                TaskStatus = dRow["TaskStatus"].ToString(),
                AssignedTo = dRow["AssignedTo"].ToString(),
                DateDue = dRow["DateDue"].ToString()
            });
        }
    }
