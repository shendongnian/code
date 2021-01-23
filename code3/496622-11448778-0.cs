        public ActionResult showDiary(string datein)
            {
                using( var dblists = new LocalTestEntities1())
                {
                var date = Convert.ToDateTime(datein);
                var thediary = dblists.ExerciseDiaries.First(o => o.Date == date);
 
                var weight = dblists.Weights.First(o => o.DiaryID ==thediary.ID);
                var sets = dblists.Sets.Where(x => x.WeightId == weight.WeightID).AsEnumerable();
        
                return View(sets);
                }
            }
