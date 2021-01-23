     public JsonResult ValidateVisit(string query)
     {
        ValidatePinViewModel model = Json.Deserialize<ValidatePinViewModel>(query);       
        return Json(new InvalidPin());
     }
