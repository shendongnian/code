    public ActionResult YourActionMethod()
    {
        CareerForm model = new CareerForm();
        model.EmploymentType = new List<CheckBox>
        {
            new Checkbox { Text = "Fulltime" },
            new Checkbox { Text = "Partly" },
            new Checkbox { Text = "Contract" }
        };
        return View(model);
    }
