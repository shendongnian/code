    [HttpGet] // Or even if you dont put this, it will be treated as GET
    public ActionResult Create()
    {
         // your code goes here
    }
    
    [HttpPost]
    public  ActionResult Create(Model yourModel)
    {
        // your code goes here 
    }
    
    in your view 
    @using(Html.BeginForm("HandleForm", "Home")
