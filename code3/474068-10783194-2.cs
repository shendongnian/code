    [HttpPost]
    public ActionResult Index2(FormCollection fc)
    {
        var goalcardWithPlannedDate = repository.GetUserGoalCardWithPlannedDate();
        return PartialView(new MyModel { Data = goalcardWithPlannedDate.Select(x => new GoalCardViewModel(x)) });
    }
