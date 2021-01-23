    public ActionResult PostHandler(ViewModel model) {
        SetCookie("redirected", "true"); // psuedocode
        return Redirect("GetHandler2");
    }
    
    public ActionResult GetHandler2() {
        if( GetCookie("redirected") == "true" ) {
            // do something
        }
        DeleteCookie("redirected");
    }
