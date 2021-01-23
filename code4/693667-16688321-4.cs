    public ActionResult YourActionMethod()
    {
        CareerForm model = new CareerForm();
        model.EmploymentType = new List<CheckBox>
        {
            new CheckBox { Text = "Fulltime" },
            new CheckBox { Text = "Partly" },
            new CheckBox { Text = "Contract" }
        };
        return View(model);
    }
