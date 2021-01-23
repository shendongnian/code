        [GridAction(EnableCustomBinding=true)]
        public ActionResult GetSerials(GridCommand command)
        {
            GridModel model = service.GetSerials(command);
            return View(model);
        }
