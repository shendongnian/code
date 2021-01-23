    [HttpPost]
    public JsonResult EditPerson(Person person) 
    {
        // code here to save person
        
        bool success = true; // somehow determine if the save was successful
        string msg = ""; // error message is needed?
        return JsonResult(new {success,msg, person});
    }
