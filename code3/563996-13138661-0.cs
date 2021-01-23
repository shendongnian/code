     public ActionResult actionname() {
            string result = getusername();
            return Content(result);
        }
    [NoneAction]
    private string getusername(){
        return (Membership.GetUser()!= null) ? Membership.GetUser().UserName : "Guest";
    }
