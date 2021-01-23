    public ActionResult Validate(int month = 0, int year = 0)
    {
        //Check if input is valid
        ValidateViewModel model = new ValidateViewModel();
        model.CanShowChart = month != 0 && year != 0;
        model.SelectedMonth = month.ToString();
        model.SelectedYear = year.ToString();
        //Populate years
        model.AvailableYears = Enumerable.Range(2008, DateTime.Now.Year - 2007).Reverse().Select(r => r.ToString());
        //Populate months
        model.AvailableMonths = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        return View(model);
    }
