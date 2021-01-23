    public ActionResult Menus(){
        List<Menu> menusource; // get your menus here
        ViewBag.Menus = CreateVM(0, menusource);  // transform it into the ViewModel
        return View();
    }
    public IEnumerable<MenuViewModel> CreateVM(int parentid, List<Menu> source)
    {
        return from men in source
               where men.ParentId = parentid
               select new MenuViewModel(){
                          MenuId = men.MenuId, 
                          Name = men.Name
                          // other properties
                          Children = CreateVM(men.MenuId, source)
                      };
    }
