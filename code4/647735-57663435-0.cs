    public ViewResult GetAdminMenu()
        {
            MyViewModelmodel = new MyViewModel();            
    
            model.ShowAdmin = userHasPermission("Admin"); 
    
            return View(model);
        }
