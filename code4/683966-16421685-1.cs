    public ActionResult Environment(SmokersModel Model)
    {
        int totalSmokers = repository.Results
            .Where(x => x.House == Model.House && x.Car == Model.Car && x.Work == Model.Work)
            .Count();
        return View();
    }
