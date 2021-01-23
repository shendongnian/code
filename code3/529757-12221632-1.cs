    //Assign these variables ahead of time so others reading your code can 
    //figure out what's going on
    var EmpID = loadEmp.Entities.Where(emp => emp.EmployeeID == _EmployeeID).First();
    var UserName = EmpID.UserName;
    var FirstName = EmpID.FirstName;
    var Title = GetTitle(EmpID.EmployeeShiftID);
    //Your original call
    Mail.Load(mail.GetMailsQuery("Workforce Attendence Issue",
         UserName,
         Title,
         FirstName,
         //...Etc
    );
    //New method you will need to add, you could do this logic in line, but this will
    //be less messy
    private string GetTitle(int ShiftID)
    {
        switch (ShiftID)
        {
             case 1:
                 return "supervisor1";
                 break;
             case 2:
                 return "supervisor2";
                 break;
             //...etc
        }
    }
