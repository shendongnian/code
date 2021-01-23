    public class PasswordController{
     
      public ActionResult Reset(string id){}
        //returns a view that has a form for them to enter their username and email
    
      [HttpPost]
      public ActionResult Reset(string id, string username, string email){}
       //derypt here and verify etc.
     }
