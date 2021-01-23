    [HttpPost]
    public ACtionResult Create(EditSeasonViewModel model)
    {
      if(ModelState.IsValid)
      {
       int clubId= model.SelectedClub;
       //to do : save and redirect (PRG pattern)
      }
      vm.Clubs=GetListOfSelectListItemFromClubsFromSomeWhere();
      return View(model);
    }
