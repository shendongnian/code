     public ActionResult Student()
        {
    RegisterViewModel vm = new RegisterViewModel();
    IEnumerable<GradeTypes> actionTypes = Enum.GetValues(typeof(GradeTypes))
                                                 .Cast<GradeTypes>();
            vm.ActionsList = from action in actionTypes
                             select new SelectListItem
                             {
                                 Text = action.ToString(),
                                 Value = action.ToString()
                             };
            return View(vm);
        }
