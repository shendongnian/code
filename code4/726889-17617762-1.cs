    public ActionResult Edit(int id)
    {
      var model = new EmployeeViewModel();
      Employee employee = db.Employees.Find(id);
      var model = new EmployeeViewModel
        {
            Items = new SelectList(new[]
            {
                new SelectListItem { Value = "1", Text = "Employee 1" },
                new SelectListItem { Value = "2", Text = "Employee 2" },
            }, "Value", "Text")
        };
      model.SelectedEmployeeList = new [] {1};
      return View(model);
    }
