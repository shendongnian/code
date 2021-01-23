     public JsonResult TeamInfo(string teamName)
     {
          return Json(new TeamDataAccess()TeamInfo(teamName), JsonRequestBehavior.AllowGet); 
     }
  
     
