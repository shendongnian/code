     public ActionResult Index()
        {
            int result;
            var model = new PersonsViewModel();
            List<person> mn = new List<person>();
            mn.Add(new person(1,"john", "adebayo", "shobanjo close jericho"));
            mn.Add(new person(2, "david", "johnson", "ibada close"));
            mn.Add(new person(3, "bayo", "olomale", "oluyole estate ringroad"));
            result =  WriteToDb(mn);
            model.Persons = mn;
            model.TotalCount = 42; // your variable
    
            return View(model);
    
        }
