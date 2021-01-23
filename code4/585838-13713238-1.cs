    string BugNumbers = "208,576,403";
    int currentUserID = 0;
    BugAssignmentList list = new BugAssignmentList
    {
        BugAssignments = BugNumbers.Split(',')
            // convert list of numbers to list of BugAssignment objects
            .Select(num => new BugAssignment 
            { 
                BugNumber = int.Parse(num.Trim()),
                UserID = currentUserID 
            })
            .ToList(),
        Name = "assignment list name"
    };
            
