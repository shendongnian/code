    public JsonResult PatientsData()
    {
       List<Patient> patients = new List<Patient>() {
          new ListItem() { FirstName= "1", LastName = "VA" }
       };
            return Json(new
            {
                aaData = patients.Select(x=> new[] {x.FirstName,x.LastName})
            },JsonRequestBehavior.AllowGet);
    }
