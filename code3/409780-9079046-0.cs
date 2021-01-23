    [HttpPost]
    public ActionResult EditOthers(OthersEditModel others)
    {
        if(ModelState.IsValid)
        {
             foreach (var item in others.others)
            {
                if(!TryValidateModel(item))
                    //Not valid
            }
        }
    }
