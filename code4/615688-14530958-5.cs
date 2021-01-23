    public ActionResult Create()
    {
      var vm=new CreateItemVM();
      vm.Manufacturers=GetManufacturerList();
      return View(vm);
    }
    private List<SelectListItem> GetManufacturerList()
    {
        List<SelectListItem> manuList=new List<SelectListItem>();
        manuList=(from p in  db.Manufacturers
                       select new SelectListItem { 
                                                   Value=p.ID.ToString(),
                                                   Text=p.Name}
                  ).ToList();
        return manuList;
    }
