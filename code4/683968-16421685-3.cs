    public ActionResult Environment(SmokersModel Model)
    {
        Model.TotalSmokers = repository.Results
            .Where(x => x.House == Model.House && x.Car == Model.Car && x.Work == Model.Work)
            .Count();
        return View(Model);
    }
