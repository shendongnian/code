    SpecificViewModel vm = new SpecificViewModel();
    
    vm.InfoMessage = Session["InfoMessage"] as string;
    Session["InfoMessage"] = null;
    
    // other code
    
    return View(vm);
