    public object Employee()
    {
        string ID {get; set;}
        string Name {get; set;}
        int Age {get; set;}
        Employee Boss{get; set;} //<-- here
    }
    
    var employee = new Employee();
    return Json(employee,JsonRequestBehavior.AllowGet); //The Boss property will cause "RecursionLimit exceeded".
