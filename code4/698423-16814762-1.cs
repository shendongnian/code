    public ActionResult Index()
    {
        var model = new PlanViewModel();
        model.Plan = CurrentPlan; //Replace this with the current plan you're editing
        model.Plans = db.Plan_S
            .Select(p => new SelectListItem
            {
                Value = p.Hours,
                Text = p.PlanNames,
                Selected = CurrentPlan.PlanNames == p.PlanNames
            })
            .ToList();
            return View(model);
        }
