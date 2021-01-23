    public IEnumerable<string> GetAllSubordinateEmployeeIdsByUserId(string userId)
    {
        // Retrieve only the fields that create the self-referencing relationship from all nodes
        var employees = (from e in GetAllEmployees()
                         select new { e.Id, e.SupervisorId });
        // Dictionary with optimal size for searching
        Dictionary<string, string> dicEmployees = new Dictionary<string, string>(employees.Count() * 4);
        // This queue holds any subordinate employees we find so that we may eventually identify their subordinates as well
        Queue<string> subordinates = new Queue<string>();
        // This list holds the child nodes we're searching for
        List<string> subordinateIds = new List<string>();
        // Load the dictionary with all nodes
        foreach (var e in employees)
        {
            dicEmployees.Add(e.Id, e.SupervisorId);
        }
        // Get the key (employee's ID) for each value (employee's supervisor's ID) that matches the value we passed in
        var directReports = (from d in dicEmployees
                             where d.Value == userId
                             select d.Key);
        // Add the child nodes to the queue
        foreach (var d in directReports)
        {
            subordinates.Enqueue(d);
        }
        // While the queue has a node in it...
        while (subordinates.Count > 0)
        {
            // Retrieve the children of the next node in the queue
            var node = subordinates.Dequeue();
            var childNodes = (from e in dicEmployees
                              where e.Value == node
                              select e.Key);
            if (childNodes.Count() != 0)
            {
                // Add the child nodes to the queue
                foreach (var c in childNodes)
                {
                    subordinates.Enqueue(c);
                }
            }
            // Add the node from the queue to the list of child nodes
            subordinateIds.Add(node);
        }
        return subordinateIds.AsEnumerable();
    }
