     public ActionResult GetUserAutoComplete(string term)
     {  
          var users = _userRepository.GetUsersByTerm(term);
          var autoCompleteData = users.Select(x => new { label = x.Name + " " + x.Surname, value = x.Name + " " + x.Surname, id = x.UserId, }).ToArray();
          return Json(data, JsonRequestBehavior.AllowGet);
    }
