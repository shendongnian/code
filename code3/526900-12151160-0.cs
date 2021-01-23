        public ActionResult Index(string date, datetime? latestDate)
        {
            var topsong = db.TopSongs;
            var topDate = db.TopDates;
            if (!latestDate.hasValue)
                latestDate = topDate.OrderByDescending(d => d.Date).FirstOrDefault();
           if (date == "PreviousDate")
            {
                latestDate = topDate.Where(d => d.Date < latestDate.Date).OrderByDescending(d => d.Date).FirstOrDefault();                
            }
            if (date == "NextDate")
            {
                latestDate = topDate.Where(d => d.Date > latestDate.Date).OrderBy(d => d.Date).FirstOrDefault();
            }
           
            .... 
            ViewBag.latestDate = latestDate
            return View();
        }
