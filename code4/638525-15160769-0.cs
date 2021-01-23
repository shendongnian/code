    var distinctRows = dt.Rows.GroupBy(x => x.RequestNumber).Select(x => x.First());
    acList.AddRange(distinctRows.Select(x => new AssignedClass
        {
            Project = x["Project"].ToString(),
            RequestNumber = x["RequestNumber"].ToString(),
            RequestId = x["RequestId"].ToString(),
            TaskType = x["TaskType"].ToString(),
            TaskId = x["TaskId"].ToString(),
            TaskStatus = x["TaskStatus"].ToString(),
            AssignedTo = x["AssignedTo"].ToString(),
            DateDue = x["DateDue"].ToString()
        });
    
