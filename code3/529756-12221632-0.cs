    var EmpID = loadEmp.Entities.Where(emp => emp.EmployeeID == _EmployeeID).First();
    var UserName = EmpID.UserName;
    var FirstName = EmpID.FirstName;
    var Title = GetTitle(EmpID.EmployeeShiftID);
    Mail.Load(mail.GetMailsQuery("Workforce Attendence Issue",
         UserName,
         Title,
         FirstName,
         //...Etc
    );
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
