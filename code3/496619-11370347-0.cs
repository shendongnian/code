    public ActionResult showDiary(string datein)
    {
        LocalTestEntities1 dblists = new LocalTestEntities1();
        DateTime date = Convert.ToDateTime(datein);
        ExerciseDiary thediary  = dblists.ExerciseDiaries.First(o => o.Date == date);
        Weight weight = dblists.Weights.First(o.DiaryID == thediary.ID);
        var sets = from x in dblists.Sets
                   where x.WeightId == weight.WeightID
                   select x;
        return View(sets);
    }
