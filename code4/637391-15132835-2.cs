public ActionResult EmployeeDetails(int id)
{
       //set other employee properties here.
       //I'm assuming you have set males to 2 and females to 1
       ...
       employeeViewObject.Gender = employeeObjectFromDB.Gender.Value==2?"Male":"Female";
       return View(employeeObjectFromDB);
}
