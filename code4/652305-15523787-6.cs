    @model EditSeasonViewModel
    @using(Html.Beginform())
    {
    
      @Html.DropdownlistFor(x=>x.SelectedClub,
                              new SelectList(Model.Clubs,"Value","Text"),"select")
      <input type="submit" />
    }
