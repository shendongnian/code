    public ActionResult ChangeHeatName(string heatName, string updatedHeat)
        {
            string user = User.Identity.Name;
            HomeModel H = new HomeModel();
            H.ChangeHeatName(heatName, updatedHeat, user);
            return PartialView("NameOfPartialView", H);
        }
