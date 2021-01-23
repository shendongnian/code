        public ActionResult Index(string date, DateTime? latestDate)
        {
            var topsong = db.TopSongs;
            var topDate = db.TopDates;
            if (!latestDate.HasValue)
                latestDate = (DateTime?)(topDate.OrderByDescending(d => d.Date).FirstOrDefault());
           if (date.Value == "PreviousDate")
            {
                latestDate = (DateTime?)(topDate.Where(d => d.Date < latestDate.Date).OrderByDescending(d => d.Date).FirstOrDefault());                
            }
            if (date.Value == "NextDate")
            {
                latestDate = (DateTime?)(topDate.Where(d => d.Date > latestDate.Date).OrderBy(d => d.Date).FirstOrDefault());
            }
           
            .... 
            ViewBag.latestDate = latestDate
            return View();
        }
