    public JsonResult Authenticate(string username,string password)
        {
            bool status = Login.Authenticate(username, password);
            return Json( new @"Status", status);
        }
