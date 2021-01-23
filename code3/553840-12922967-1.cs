    public ActionResult Index()
    {
        var vm= new OrderViewModel();
     
        //the below is hard coded for DEMO. you may get the data from some  
        //other place and set the course and options
     
        var q1 = new Course { ID = 1, Name= "Starters" };
        q1.Options.Add(new Option{ ID = 12, Title = "Prawn Cocktail " });
        q1.Options.Add(new Option{ ID = 13, Title = "Soup" });
        vm.Options.Add(q1);     
        var q2 = new Course { ID = 1, Name= "Mains" };
        q2.Options.Add(new Option{ ID = 42, Title = "Beef" });
        q2.Options.Add(new Option{ ID = 43, Title = "Lamp" });
        vm.Options.Add(q2);
         
       return View(vm);           
    }
