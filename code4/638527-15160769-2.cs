    var distinctRows = dt.Rows.GroupBy(x => x["RequestNumber"]).Select(x => x.First());
    acList.AddRange(distinctRows.Select(x => x.MapToAssignedClass());
    
    // Added Mapping method for readability
    public static AssignedClass MapToAssignedClass(this DataRow dr)
    {
        return new AssignedClass
        {
            Project = dr["Project"].ToString(),
            RequestNumber = dr["RequestNumber"].ToString(),
            RequestId = dr["RequestId"].ToString(),
            TaskType = dr["TaskType"].ToString(),
            TaskId = dr["TaskId"].ToString(),
            TaskStatus = dr["TaskStatus"].ToString(),
            AssignedTo = dr["AssignedTo"].ToString(),
            DateDue = dr["DateDue"].ToString()
        });
    }
