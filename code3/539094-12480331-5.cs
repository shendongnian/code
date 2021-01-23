    IList<Project> projects = (from update in dbContext.TicketUpdates where update.TicketUpdatesEmployeeID == Profile.EmployeeID)
        .Distinct(new ProjectComparer())
        .OrderByDescending(tu=>tu.TicketUpdatesEndDate)
        .Select(tu=>tu.Ticket.Project)
        .ToList();
    
    
    // Your comparer should look somewhat like this 
    // (untested code! And I do not know all the details about your class structure)
    class ProjectComparer : IEqualityComparer<TicketUpdates>
    {
        // Products are equal if their names and product numbers are equal. 
        public bool Equals(TicketUpdates x, TicketUpdates y)
        {
    
            //Check whether the compared objects reference the same data. 
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether any of the compared objects is null. 
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            //Check whether projects are equal. 
            //(perhaps do a null check for Ticket!)
            return x.Ticket.Project== y.Ticket.Project;
        }
    
        // If Equals() returns true for a pair of objects  
        // then GetHashCode() must return the same value for these objects. 
    
        public int GetHashCode(TicketUpdates x)
        {
            //Check whether the object is null 
            if (Object.ReferenceEquals(x, null)) return 0;
    
            // null check for Ticket and Project?
            return x.Ticket.Project.GetHashCode();
        }
    
    }
