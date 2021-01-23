    public ActionResult _ChartHome()
        {
            var ChAd = db.Charts
            .Where(v => v.ChOk == true)
            .OrderBy(v => v.ChPosition)
               .Take(10);
            ViewBag.First = ChAd.FirstOrDefault();
            return PartialView(ChAd);
        }
