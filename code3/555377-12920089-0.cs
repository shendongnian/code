    //Assume managerName is "Mark" and employeeName is "Jim", as in your example above
    public bool isManagerValid(string managerName, string employeeName)
    {
        bool valid = true;
        var manager = getEmployee("Mark"); //The "to-be" manager of Jim
        var employee= getEmployee("Jim");
        var currentManager = getEmployee(manager.Manager); //Get Marks manager
        while(currentManager != null && valid)
        {
            if(currentManager == employee)
            {
                valid = false; //Some manager up the line from Mark is already Jim 
            }
            else
            {
                //Get the next manager up
                currentManager = getEmployee(currentManager.Manager);
            }
        }
        return valid;
    }
