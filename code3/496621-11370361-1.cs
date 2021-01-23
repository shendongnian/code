    public ActionResult showDiary(string datein)
    {
        using (LocalTestEntities1 dblists = new LocalTestEntities1())
        {
            DateTime date = Convert.ToDateTime(datein);
            var thediary = (from o in dblists.ExerciseDiaries 
                            where o.Date == date 
                            select o).First();
            var weight = (from o in dblists.Weights 
                          where o.DiaryID == thediary.ID 
                          select o).First();
            var sets = (from x in dblists.Sets 
                        where x.WeightId == weight.WeightID 
                        select x).ToList();
        }
        return View(sets);
    }
