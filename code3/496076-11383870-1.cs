    public ActionResult CreatePage( string cssClass ) {
       // Initialize the entire view model for the partial view here
       // This usually means you need to pass in an id and use it to
       // make a database lookup.
       // If it's "too much work", it probably means you
       // need to fix a structural problem.
       APartialModel model = new APartialModel
           {
               Name = "Somehow I already know this value",
               CssClass = cssClass
           };
       return PartialView( "APage", model );
    }
