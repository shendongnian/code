    //Somewhere in the controller
    ...
    var list = yourViewModel.SelectedTeam.TeamPlayers.OrderBy(p => p.LastName).Select(new SelectListItem
        {
            Text = item.LastName,
            Value = item.Disabled ? "disabled" : item.PlayerId.ToString()
        }).ToList();
    //pass it however you want, in the model or by ViewBag
    ViewBag.MyDropDownList = new SelectList(list, "Value", "Text");
