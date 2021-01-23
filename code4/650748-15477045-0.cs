    public ActionResult ThankYou(string msg)
    {
      var vm=YourSuccessViewModel();
      if(msg="success") // you may do a null checking before accessing this value
      {
        vm.Message="Saved Successfully";
      }
      return View(vm);  
    }
