    public ActionResult AssignDoctor
    {
      var vm=new AssignDoctorViewModel();
      vm.Hospitals= new[]
        {
              new SelectListItem { Value = "1", Text = "Florance" },
              new SelectListItem { Value = "2", Text = "Spark" },
              new SelectListItem { Value = "3", Text = "Henry Ford" },
        };
        // can replace the above line with loading data from Data access layer.
       return View(vm);
    }
