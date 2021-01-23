    public ActionResult create(int id)
    {
      var vm=new EditSeasonViewModel();
      vm.Clubs=GetListOfSelectListItemFromClubsFromSomeWhere();
      return View(vm);
    }
