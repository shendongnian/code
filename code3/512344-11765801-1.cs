    public PartialViewResult PlannedSpecialty()
    { 
        var pgtServ = new PgtService();
        var vm=new PlannedSpecialty();
        vm.SpecialtyItems = pgtServ.GetPlannedSpecialtyDropDownItems();    
  
       //just hard coding for demo. you may get the value from some source.  
        vm.SelectedSpeciality=25;//  here you are setting the selected value.
       return View(vm);
    }
