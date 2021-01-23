    [HttpGet]
    public ActionResult Results(AssessmentModel assessment)
    {
        int rows = myTable.Where(x => x.SmokesInHouse == assessment.SmokesInHouse &&
                                      x.SmokesInCar == assessment.SmokesInCar &&
                                      x.SmokesAtWork == assessment.SmokesInWork).Count();
        return View(rows);
    }
